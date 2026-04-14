using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data;


namespace OffersSearchApp
{
    public class WordReportService
    {
        public static void GenerateWordReport(DataTable offersTable, string quarter)
        {
            if (offersTable == null || offersTable.Rows.Count == 0)
            {
                MessageBox.Show("No data available to generate the report!");
                return;
            }

            // تصفية البيانات حسب الربع
            var data = offersTable.AsEnumerable()
                .Where(r => r["Quarter"].ToString() == quarter)
                .ToList();

            if (data.Count == 0)
            {
                MessageBox.Show($"No data available for quarter {quarter}!");
                return;
            }

            using var sfd = new SaveFileDialog();
            sfd.Filter = "Word Document|*.docx";
            sfd.FileName = "Report_" + quarter + ".docx";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            string filePath = sfd.FileName;
            string templatePath = @"C:\Users\md\Desktop\Code\OffersSearchApp\OffersSearchApp\Templates\ReportTemplate.dotx";

            try
            {
                File.Copy(templatePath, filePath, true);

                using (var doc = WordprocessingDocument.Open(filePath, true))
                {
                    doc.ChangeDocumentType(WordprocessingDocumentType.Document);
                    if (doc.MainDocumentPart?.Document?.Body == null)
                    {
                        MessageBox.Show("Error in Word file structure!");
                        return;
                    }

                    var body = doc.MainDocumentPart.Document.Body;

                    int productsCount = data.Select(r => r["ProductName"].ToString()).Distinct().Count();
                    int suppliersCount = data.Select(r => r["SupplierName"].ToString()).Distinct().Count();

                    var replacements = new Dictionary<string, string>
                    {
                        { "{{DATE}}", DateTime.Now.ToString("dd/MM/yyyy") },
                        { "{{TITLE1}}", "تقرير عروض الأسعار" },
                        { "{{INTRO1}}", "يهدف هذا التقرير إلى توثيق وحصر الموردين الذين تم التواصل معهم خلال الفترة الماضية، وذلك ضمن جهود القسم في البحث عن أفضل العروض المتاحة للأصناف المطلوبة." },
                        { "{{INTRO2}}", "يعرض التقرير قائمة الموردين الذين جرى التواصل معهم، مع توضيح الأصناف التي تم البحث عنها لدى كل مورد، والأسعار المقترحة لكل صنف حسب العروض المستلمة." },
                        { "{{INTRO3}}", "كما يوضح التقرير مدى توفر الأصناف في السوق وعدد الموردين الذين استجابوا لكل صنف، مما يساعد على تقييم سهولة أو صعوبة الحصول على بعض المنتجات." },
                        
                        { "{{TITLE2}}", "1. ملخص عدد الأصناف والموردين" },
                        { "{{INTRO4}}", "يتضمن هذا القسم معلومات حول الأصناف المتاحة وعدد الموردين لكل صنف، بالإضافة إلى إجمالي عدد الموردين" },
                        { "{{INTRO5}}", $"تم البحث عن {productsCount} صنف خلال الفترة الأخيرة." },
                        { "{{INTRO6}}", $"إجمالي عدد الموردين {suppliersCount} مورد." },
                        { "{{INTRO7}}", "وهذا الجدول تفصيل عدد الموردين لكل صنف:" },

                        { "{{TITLE3}}", "2. ملخص الأسعار لكل صنف" },
                        { "{{INTRO8}}", "يوضح هذا القسم مقارنة الأسعار المقدمة من الموردين لكل صنف، مع تحديد المورد الأرخص." },
                        { "{{INTRO9}}", "جدول تفصيل الأسعار المقدمة لكل صنف:" },
                        { "{{TITLE4}}", "3. جدول تفصيل أفضل الموردين لكل صنف:" }
                    };

                    
                    var paragraphs = body.Descendants<Paragraph>().ToList();
                    foreach (var para in paragraphs)
                    {
                        foreach (var kvp in replacements)
                        {
                            if (para.InnerText.Contains(kvp.Key))
                            {
                                ReplaceTextInParagraph(para, kvp.Key, kvp.Value);
                            }
                        }
                    }

                    ReplaceTagWithTable(body, "{{SUPPLIERS_TABLE}}", BuildSupplierTable(data));
                    ReplaceTagWithTable(body, "{{PRICES_TABLE}}", BuildPriceTable(data));
                    ReplaceTagWithTable(body, "{{BEST_SUPPLIER}}", BuildBestSupplierTable(data));

                    doc.MainDocumentPart.Document.Save();
                }
                MessageBox.Show("Report generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private static void ReplaceTextInParagraph(Paragraph para, string search, string replace)
        {
            var texts = para.Descendants<Text>().ToList();
            if (texts.Count == 0) return;
            string fullText = para.InnerText;
            if (fullText.Contains(search))
            {
                string newText = fullText.Replace(search, replace);
                foreach (var t in texts) t.Text = "";
                texts[0].Text = newText;
            }
        }

        private static void ReplaceTagWithTable(Body body, string tag, Table table)
        {
            var para = body.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains(tag));
            if (para != null)
            {
                if (para?.Parent != null)
                {
                    para.Parent.InsertAfter(table, para);
                    para.Remove();
                }
            }
        }

        private static Table BuildSupplierTable(List<DataRow> data)
        {
            Table table = CreatePlainTable5();
            table.Append(CreateRow([ "Product Name", "Supplier Count" ], isHeader: true));

            var grouped = data.GroupBy(r => r["ProductName"].ToString())
                .Select(g => new
                {
                    Product = g.Key,
                    Count = g.Select(x => x["SupplierName"].ToString()).Distinct().Count()
                }).ToList();

            for (int i = 0; i < grouped.Count; i++)
            {
                var item = grouped[i];
                table.Append(CreateRow([ item.Product!, item.Count.ToString() ], rowIndex: i));
            }
            return table;
        }

        private static Table BuildPriceTable(List<DataRow> data)
        {
            Table table = CreatePlainTable5();
            table.Append(CreateRow([ "Product Name", "Cheapest Price", "Most Expensive Price", "Average Price" ], isHeader: true));

            var grouped = data.GroupBy(r => r["ProductName"].ToString())
                .Select(g =>
                {
                    var prices = g.Select(x => x.Field<decimal?>("Price")).Where(p => p.HasValue).Select(p => p!.Value).ToList();
                    return new
                    {
                        Product = g.Key,
                        Min = prices.Min(),
                        Max = prices.Max(),
                        Avg = prices.Average()
                    };
                }).ToList();

            for (int i = 0; i < grouped.Count; i++)
            {
                var item = grouped[i];
                table.Append(CreateRow([item.Product!, $"${item.Min:F2}", $"${item.Max:F2}", $"${item.Avg:F2}" ], rowIndex: i));
            }
            return table;
        }

        private static Table BuildBestSupplierTable(List<DataRow> data)
        {
            Table table = CreatePlainTable5();
            table.Append(CreateRow([ "ProductName", "SupplierName", "Price" ], isHeader: true));

            var best = data.GroupBy(r => r["ProductName"].ToString())
                .Select(g =>
                {
                    var validPrices = g.Where(x => x["Price"] != DBNull.Value);
                    if (!validPrices.Any())
                        return new { Product = g.Key, Supplier = "Not Available", Price = 0m };

                    var min = validPrices.OrderBy(x => Convert.ToDecimal(x["Price"])).First();
                    return new
                    {
                        Product = g.Key,
                        Supplier = min["SupplierName"].ToString()!,
                        Price = Convert.ToDecimal(min["Price"])
                    };
                }).ToList();

            for (int i = 0; i < best.Count; i++)
            {
                var item = best[i];
                table.Append(CreateRow(
                    [item.Product!, item.Supplier, $"${item.Price:F2}" ],
                    rowIndex: i,
                    customWidths: [ 2448, 4320, 1008 ]
                ));
            }
            return table;
        }

        private static Table CreatePlainTable5()
        {
            var table = new Table();
            var tblProps = new TableProperties(
                new TableBorders(
                    new TopBorder { Val = BorderValues.None },
                    new BottomBorder { Val = BorderValues.None },
                    new LeftBorder { Val = BorderValues.None },
                    new RightBorder { Val = BorderValues.None },
                    new InsideHorizontalBorder { Val = BorderValues.None },
                    new InsideVerticalBorder { Val = BorderValues.None }
                ),
                new TableLayout { Type = TableLayoutValues.Autofit },
                new TableJustification { Val = TableRowAlignmentValues.Center }
            );
            table.AppendChild(tblProps);
            return table;
        }

        private static TableRow CreateRow(string[] cellTexts, bool isHeader = false, int rowIndex = -1, int[]? customWidths = null)
        {
            var row = new TableRow();
            row.AppendChild(new TableRowProperties(new TableRowHeight() { Val = 288, HeightType = HeightRuleValues.Exact }));

            for (int i = 0; i < cellTexts.Length; i++)
            {
                string bgColor = (i == 0) ? "FFFFFF" : (isHeader ? "FFFFFF" : (rowIndex % 2 == 0 ? "F2F2F2" : "FFFFFF"));
                int width = (customWidths != null && i < customWidths.Length) ? customWidths[i] : 2304;
                string currentFontSize = (i == 0) ? "24" : "22";
                bool bold = isHeader;
                bool italic = isHeader || (i == 0);
                bool bottomBorder = isHeader;
                bool rightBorder = !isHeader && (i == 0);

                row.Append(CreateTableCell(cellTexts[i], bgColor, width, italic, bold, rightBorder, bottomBorder, currentFontSize));
            }
            return row;
        }

        private static TableCell CreateTableCell(string text, string bgColor, int width, bool italic, bool bold, bool rightBorder, bool bottomBorder, string fontSize = "24")
        {
            var runProps = new RunProperties(
                new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize() { Val = fontSize },
                new FontSizeComplexScript() { Val = fontSize }
            );

            if (italic) runProps.Append(new Italic());
            if (bold) runProps.Append(new Bold(), new BoldComplexScript());

            var cell = new TableCell(
                new Paragraph(new Run(runProps, new Text(text) { Space = SpaceProcessingModeValues.Preserve }))
                {
                    ParagraphProperties = new ParagraphProperties(
                        new Justification() { Val = JustificationValues.Center },
                        new BiDi() { Val = OnOffValue.FromBoolean(true) },
                        new SpacingBetweenLines() { After = "0", Before = "0" }
                    )
                }
            );

            var tcp = GetCellProperties(bgColor, width);
            if (rightBorder || bottomBorder)
            {
                var borders = new TableCellBorders();
                if (rightBorder) borders.Append(new RightBorder { Val = BorderValues.Single, Size = 4, Color = "000000" });
                if (bottomBorder) borders.Append(new BottomBorder { Val = BorderValues.Single, Size = 4, Color = "000000" });
                tcp.Append(borders);
            }
            cell.Append(tcp);
            return cell;
        }

        private static TableCellProperties GetCellProperties(string bgColor = "FFFFFF", int widthTwips = 2304)
        {
            var tcp = new TableCellProperties();
            tcp.Append(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = widthTwips.ToString() });
            if (!string.IsNullOrEmpty(bgColor))
            {
                tcp.Append(new Shading { Color = "auto", Fill = bgColor, Val = ShadingPatternValues.Clear });
            }
            tcp.Append(new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center });
            return tcp;
        }
    }
}