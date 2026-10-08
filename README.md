# OffersSearchApp

## Offers & Suppliers Management System

A Windows Forms desktop application built with C# and .NET for managing supplier offers, procurement data, and supplier information.

The application provides a centralized interface for storing, searching, comparing, importing, exporting, and reporting supplier offers.

---

## Overview

OffersSearchApp is designed for organizations that manage multiple supplier quotations and need an efficient way to organize and evaluate purchasing data.

The system allows users to:

- Manage supplier offers and supplier information.
- Search and filter large datasets in real time.
- Sort offers by different columns.
- Import data from Excel and CSV files.
- Export offer data to CSV.
- Select and compare supplier offers.
- Generate professional Word reports from templates.
- Switch between Light and Dark themes.
- Track application activities and errors through logging.

---

## Key Features

### 🔍 Advanced Search

- Real-time search across multiple fields.
- Supports both text and numeric columns.
- Uses `DataView.RowFilter` for fast in-memory filtering.

### ↕️ Interactive Sorting

- Sort data by clicking column headers.
- Supports ascending and descending order.
- Maintains the current sorting state.

### 📥 Excel & CSV Import

Supports importing:

- `.xlsx`
- `.xls`
- `.csv`

Excel files are processed using Microsoft ACE OLE DB, while CSV files are parsed using a custom CSV parser.

### 📤 CSV Export

Exports offer data to CSV while correctly handling:

- Commas inside values.
- Quotation marks.
- Empty values.
- UTF-8 encoding.

### 📄 Automated Word Reports

Generates `.docx` reports from Word templates using the OpenXML SDK.

The reporting system supports dynamic placeholders such as:

{{DATE}} {{TITLE1}} {{INTRO1}} {{SUPPLIERS_TABLE}}


It can also generate dynamic tables containing:

- Suppliers per product.
- Minimum, maximum, and average prices.
- Selected suppliers and their prices.

### 👥 Supplier Management

Provides a dedicated interface for managing supplier information, including:

- Supplier details.
- Contact information.
- Country.
- Registration information.
- Products and services.
- Account opening date.
- Notes.
- Financial information.

### ✅ Offer Selection

Users can mark specific offers as selected.

Selected offers can then be used to identify the preferred supplier and support purchasing decisions.

### 🌙 Light & Dark Mode

The application includes a dynamic theme system with:

- Light mode.
- Dark mode.
- Persistent theme preferences.
- Automatic theme updates across forms.

### 📝 Logging

A custom logging system records important application events, including:

- Application startup.
- Database operations.
- Save operations.
- Errors.
- Theme changes.
- Form activities.

### 🖱️ Drag & Drop

The offer data grid supports dragging text and dropping it directly into cells.

## Architecture

The application follows a **Separation of Concerns** approach, dividing the system into several logical layers.

### Project Structure

| Component | Responsibility |
|---|---|
| **Forms** | User interface and application screens |
| `Form1.cs` | Main offers management screen |
| `FormAddItem.cs` | Add and edit offers |
| `FormEditOffer.cs` | Edit individual offers |
| `FormSuppliers.cs` | Supplier management |
| `FormLogs.cs` | View application logs |
| **Services** | Application services |
| `ExcelExportService.cs` | Export data to CSV |
| `ImportService.cs` | Import Excel and CSV data |
| `WordReportService.cs` | Generate Word reports |
| **Infrastructure** | Shared application components |
| `Logger.cs` | Application logging |
| `ThemeManager.cs` | Light/Dark theme management |
| `BaseThemeForm.cs` | Shared theme functionality |
| `Program.cs` | Application entry point |


### Presentation Layer

Contains the Windows Forms responsible for user interaction and application workflows.

- Main offers management
- Offer creation and editing
- Supplier management
- Application logs
- User interaction and UI controls

### Service Layer

Contains reusable services responsible for specific application operations.

- Importing Excel and CSV data
- Exporting data to CSV
- Generating automated Word reports

### Infrastructure Layer

Provides shared functionality used across the application.

- Application logging
- Light/Dark theme management
- Shared base form functionality
- Common UI behavior

### Data Layer

Handles communication with the MySQL database using:

- ADO.NET
- `MySql.Data`
- `MySqlConnection`
- `MySqlCommand`
- `MySqlDataAdapter`
- `DataTable`
- `DataView`

---

## Database

The application uses **MySQL** as its relational database.

### Main Tables

#### Offers

Stores supplier quotation and offer information, including:

- Product name
- Supplier name
- Contact information
- Country
- Quantity
- Price
- Material
- Size
- Type
- Quarter
- Selection status

#### Suppliers

Stores supplier information, including:

- Supplier name
- Address
- Country
- Company owner information
- Contact person information
- Registration number
- Goods and services
- Account opening date
- Notes
- Amount

---

## Technology Stack

### Application

- **C#**
- **.NET**
- **Windows Forms**

### Database & Data Access

- **MySQL**
- **ADO.NET**
- **MySql.Data**
- `DataTable`
- `DataView`
- `MySqlDataAdapter`

### Document & Data Processing

- **OpenXML SDK** — Word document generation
- **Microsoft ACE OLE DB** — Excel data import
- **CSV Processing** — Custom CSV parsing and export

### Design & Architecture

- Separation of Concerns
- Static Service Classes
- Inheritance
- Observer Pattern
- Event-driven UI
- Reusable Base Form

---

## Security & Reliability

The application includes several practices to improve security, reliability, and resource management.

- Parameterized SQL queries to help prevent SQL injection.
- Proper database connection disposal using `using`.
- Exception handling around database operations.
- Custom application logging.
- Proper CSV escaping for commas and quotation marks.
- Nullable value handling for database fields.
- Controlled database operations for inserting and updating records.

> **Important:** Database credentials and connection strings should never be committed to the repository. Use configuration files or environment-specific settings instead.

---

## Project Goals

The main goal of **OffersSearchApp** is to simplify the management of supplier quotations and make purchasing data easier to search, compare, analyze, and report.

The project combines a business-oriented workflow with practical desktop application development concepts, including:

- Database-driven application development
- Data manipulation and filtering
- Excel and CSV import/export
- Automated document generation
- UI/UX customization
- Event-driven programming
- Reusable application services
- Error handling and logging

---

## 💡 Author

**Abdulrahman Alhomaidi**  
GitHub: [https://github.com/Alhomaidi3](https://github.com/Alhomaidi3)  
LinkedIn: [https://www.linkedin.com/in/Alhomaidi3](https://www.linkedin.com/in/Alhomaidi3)
