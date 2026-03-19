using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Data;

namespace OffersSearchApp2
{
    public class WordReportService
    {
        public static void GenerateWordReport(DataTable offersTable, string quarter)
        {
            if (offersTable == null || offersTable.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات!");
                return;
            }

            var data = offersTable.AsEnumerable()
                .Where(r => r["Quarter"].ToString() == quarter)
                .ToList();

            if (data.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذا الربع!");
                return;
            }

            using var sfd = new SaveFileDialog();
            {
                sfd.Filter = "Word Document|*.docx";
                sfd.Title = "حفظ التقرير كملف Word";
                sfd.FileName = $"Report_{quarter}.docx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = sfd.FileName;

                using var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = new Body();
                    body.Append(FormatText(""));

                    body.Append(FormatText("تقرير عروض الاسعار ", fontSize: 36, isBold: true, isUnderline: true, isTitle: true));
                    body.Append(FormatText(""));

                    body.Append(FormatText($"التاريخ                                                                                                                                {DateTime.Now:dd/MM/yyyy} "));
                    AppendEmptyLines(body, 8);
                    body.Append(FormatText("يهدف هذا التقرير إلى توثيق وحصر الموردين الذين تم التواصل معهم خلال الفترة الماضية، وذلك ضمن جهود القسم في البحث عن أفضل العروض المتاحة للأصناف المطلوبة                                                                                  ."));
                    body.Append(FormatText(""));
                    body.Append(FormatText("يعرض التقرير قائمة الموردين الذين جرى التواصل معهم، مع توضيح الأصناف التي تم البحث عنها لدى كل مورد، والأسعار المقترحة لكل صنف حسب العروض المستلمة.                                                                                                  "));
                    body.Append(FormatText(""));
                    body.Append(FormatText("كما يوضح التقرير مدى توفر الأصناف في السوق وعدد الموردين الذين استجابوا لكل صنف، مما يساعد على تقييم سهولة أو صعوبة الحصول على بعض المنتجات                                                                                                         ."));
                    AppendEmptyLines(body, 9);


                    AddSummary(body, data);
                    AddSupplierTable(body, data);
                    AddPriceTable(body, data);
                    AddBestSupplierTable(body, data);

                    mainPart.Document.Append(body);
                }
            }
        }

        private static Paragraph FormatText(string text, int fontSize = 24, bool isBold = false, bool isUnderline = false, bool isTitle = false)
        {
            var runProps = new RunProperties(
                new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" },
                new FontSize() { Val = fontSize.ToString() },
                new FontSizeComplexScript() { Val = fontSize.ToString() }
            );

            if (isBold) runProps.Append(new Bold(), new BoldComplexScript());
            if (isUnderline) runProps.Append(new Underline() { Val = UnderlineValues.Single });

            var paragraph = new Paragraph(
                new Run(runProps, new Text(text) { Space = SpaceProcessingModeValues.Preserve })
            );

            var paraProps = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center },
                new BiDi() { Val = OnOffValue.FromBoolean(true) } 
            );

            if (isTitle)
            {
                paraProps.Append(new SpacingBetweenLines() { Before = "200", After = "200" });
            }

            paragraph.ParagraphProperties = paraProps;
            return paragraph;
        }
        private static void AppendEmptyLines(Body body, int count)
        {
            for (int i = 0; i < count; i++)
            {
                body.Append(FormatText(""));
            }
        }

        private static void AddSummary(Body body, List<DataRow> data)
        {
            var products = data.Select(r => r["ProductName"].ToString()).Distinct().Count();
            var suppliers = data.Select(r => r["SupplierName"].ToString()).Distinct().Count();

            body.Append(FormatText(" .1ملخص عدد الأصناف والموردين", fontSize: 36, isBold: true, isUnderline: true, isTitle: true));
            body.Append(FormatText(""));
            body.Append(FormatText("يتضمن هذا القسم معلومات حول الأصناف المتاحة وعدد الموردين لكل صنف، بالإضافة إلى إجمالي عدد الموردين             "));
            body.Append(FormatText($"تم البحث عن {products} صنف خلال الفترة الأخيرة                                                                                                    "));
            body.Append(FormatText($"إجمالي عدد الموردين {suppliers} مورد                                                                                                                  "));
        }

        private static void AddSupplierTable(Body body, List<DataRow> data)
        {
            body.Append(FormatText("وهذا الجدول تفصيل عدد الموردين لكل صنف                                                                                                 :"));
            body.Append(FormatText(""));

            Table table = CreatePlainTable5();
            table.Append(CreateRow(new[] { "Product Name", "Supplier Count" }, isHeader: true));

            var grouped = data.GroupBy(r => r["ProductName"].ToString())
                .Select(g => new
                {
                    Product = g.Key,
                    Count = g.Select(x => x["SupplierName"].ToString()).Distinct().Count()
                }).ToList();

            for (int i = 0; i < grouped.Count; i++)
            {
                var item = grouped[i];
                table.Append(CreateRow(new[] { item.Product!, item.Count.ToString() }, rowIndex: i));
            }

            body.Append(table);
        }

        private static void AddPriceTable(Body body, List<DataRow> data)
        {
            // فواصل وعناوين
            AppendEmptyLines(body, 2);
            body.Append(FormatText(" .2ملخص الأسعار لكل صنف", fontSize: 36, isBold: true, isUnderline: true, isTitle: true));
            body.Append(FormatText(""));
            body.Append(FormatText("يوضح هذا القسم مقارنة الأسعار المقدمة من الموردين لكل صنف، مع تحديد المورد الأرخص                                       "));
            body.Append(FormatText(""));
            body.Append(FormatText("جدول تفصيل الأسعار المقدمة لكل صنف                                                                                                        :"));
            body.Append(FormatText(""));

            // إنشاء الجدول
            Table table = CreatePlainTable5();
            table.Append(CreateRow(new[] { "Product Name", "Cheapest Price", "Most Expensive Price", "Average Price" }, isHeader: true));
            // تجميع البيانات حسب الصنف
            var grouped = data.GroupBy(r => r["ProductName"].ToString())
                .Select(g =>
                {
                    // جميع الأسعار الصالحة فقط (غير فارغة)
                    var prices = g.Select(x => x.Field<decimal?>("Price")).Where(p => p.HasValue).Select(p => p!.Value).ToList();

                    return new
                    {
                        Product = g.Key,
                        Min = prices.Min(),
                        Max = prices.Max(),
                        Avg = prices.Average()
                };
                })
                .ToList();

            for (int i = 0; i < grouped.Count; i++)
            {
                var item = grouped[i];
                table.Append(CreateRow(new[] {
                    item.Product!,
                    $"${item.Min:F2}",
                    $"${item.Max:F2}",
                    $"${item.Avg:F2}"
                }, rowIndex: i));
            }

            body.Append(table);
        }

        private static void AddBestSupplierTable(Body body, List<DataRow> data)
        {
            AppendEmptyLines(body, 4);
            body.Append(FormatText(" .3جدول تفصيل أفضل الموردين لكل صنف:", fontSize: 36, isBold: true, isUnderline: true, isTitle: true));
            AppendEmptyLines(body, 3);

            Table table = CreatePlainTable5();
            table.Append(CreateRow(new[] { "ProductName", "SupplierName", "Price" }, isHeader: true));
                
            var best = data.GroupBy(r => r["ProductName"].ToString())
                .Select(g =>
                {
                    var validPrices = g.Where(x => x["Price"] != DBNull.Value);
                    if (!validPrices.Any())
                        return new
                        {
                            Product = g.Key,
                            Supplier = "لا يوجد",
                            Price = 0m
                        };

                    var min = validPrices.OrderBy(x => Convert.ToDecimal(x["Price"])).First();

                    return new
                    {
                        Product = g.Key,
                        Supplier = min["SupplierName"].ToString()!,
                        Price = Convert.ToDecimal(min["Price"])
                    };
                }).ToList();

            // إضافة الصفوف باستخدام الدالة الجديدة
            for (int i = 0; i < best.Count; i++)
            {
                var item = best[i];
                table.Append(CreateRow(
                    new[] { item.Product!, item.Supplier, $"${item.Price:F2}" },
                    rowIndex: i,
                    customWidths: new[] { 2448, 4320, 1008 } 
                ));
            }

            body.Append(table);
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
                string bgColor;
                if (i == 0)
                    bgColor = "FFFFFF";
                else
                bgColor = isHeader ? "FFFFFF" : (rowIndex % 2 == 0 ? "F2F2F2" : "FFFFFF");

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
                new Paragraph(
                    new Run(runProps, new Text(text) { Space = SpaceProcessingModeValues.Preserve })
                )
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
                tcp.Append(new Shading
                {
                    Color = "auto",
                    Fill = bgColor,
                    Val = ShadingPatternValues.Clear
                });
            }

            tcp.Append(new TableCellVerticalAlignment
            {
                Val = TableVerticalAlignmentValues.Center
            });

            return tcp;
        }
    }
}