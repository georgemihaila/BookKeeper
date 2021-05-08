# BookKeeper

A Windows desktop **library (book) management application** written in C# WinForms (.NET Framework 4.7.1). BookKeeper lets a user catalog books (with cover images, descriptions, categories and available quantities), search and sort the collection, lend and return books to named loaners, track loan history, see which books are most popular, and export reports to plain text.

> Note: although sometimes described as a "WAP/WPF" project, the committed code is a **WinForms** application (`System.Windows.Forms`, `OutputType WinExe`, .NET Framework 4.7.1), not WPF.

## Features / What it can do

- **Book catalog** stored in a local **SQLite** database (`BookKeeperDatabase.db`, EF6 provider) with title, author, description, category, available quantity, cover image (BLOB) and ID.
- **Dashboard tab** – books displayed as a responsive grid of thumbnail cards (cover image, title, author, description, availability); the grid reflows when the window is resized.
- **Search** – live, cancellable search across title, author and description (or by quantity/ID when the query is numeric); text is normalized (uppercase, special characters stripped) before matching.
- **Sorting** – books can be sorted by title, author, description, category, quantity, or ID (ascending/descending) directly in the SQL query.
- **Add a book** two ways:
  - Manually via the "New book" tab (title, author, description, category, quantity, image picked from disk).
  - **Auto-fill from a Book Depository URL** – fetches the product page, parses the HTML with HtmlAgilityPack and extracts the title, author(s), description, and cover image URL.
- **Book details tab** – opened per book: shows cover, full description, availability, and a "Currently lent to" list with lend/return actions.
- **Lending/returning** – two dialogs:
  - `LendBookDialog` (lend a specific book by ID)
  - `LendBookDialog_Full` (lend any book from a dropdown)
  - Loan dates are constrained to today onward with return date between +1 and +14 days. Lending decrements, returning increments, the book's available quantity in the database.
- **Loans tab** – a sortable `ListView` (by book ID, loaner name, loan date, return date), with its own live search box and a book preview thumbnail; selected loans can be returned directly from this tab.
- **Popularity chart** – a pixel-drawn bar chart showing the most-loaned books (with rotated labels and loan counts).
- **Reports** – export all loans to `Reports/loans.txt` and all books to `Reports/books.txt`, with an option to open the file.
- **Persistence/caching** – on exit the book list is binary-serialized to `Data/books.bin`; cover images are cached to `Cache/<id>.jpg` when read from the database; exceptions are logged to `Cache/exceptions.log`.
- **Tab management** – right-click context menu on tabs to close the current or all detail tabs.
- **About dialog** with links to the author's GitHub and email.

## Project structure

```
BookKeeper/
├── BookKeeper.sln
├── BookKeeper/
│   ├── BookKeeper.csproj          # Legacy (non-SDK) WinForms project, .NET Framework 4.7.1
│   ├── App.config                 # EF6 + SQLite provider registration
│   ├── packages.config            # NuGet package list
│   ├── BookKeeperDatabase.db      # SQLite database (copied to output)
│   ├── Program.cs                 # Entry point
│   ├── MainWindow.cs/.Designer    # Main form: Dashboard + Loans tabs, menus, chart
│   ├── Book.cs                    # Book entity (serializable, IComparable/ICloneable)
│   ├── BookLoan.cs                # Loan entity + ListViewItem conversion
│   ├── BookThumbnail.cs           # Thumbnail card UserControl
│   ├── BookAddDialog.cs           # Add-book UserControl (manual + Book Depository)
│   ├── BookDetailsDialog.cs       # Per-book detail/loans UserControl
│   ├── LendBookDialog.cs          # Lend specific book (by ID)
│   ├── LendBookDialog_Full.cs     # Lend any book (combo box)
│   ├── About.cs                   # About dialog
│   ├── CustomAttributes.cs        # Dev helper attributes (Incomplete, etc.)
│   ├── Utilities.cs               # Database (SQLite), string/image/exception helpers
│   ├── LinesOfCode.txt            # cloc statistics snapshots (2018)
│   ├── Properties/                # Assembly info, settings, resources
│   ├── Icons/                     # Toolbar/menu icons (png/svg/bmp/xaml)
│   └── Thumbnails/                # Sample book cover
```

## Tech stack

- **Language/Framework:** C# on **.NET Framework 4.7.1** (`v4.7.1`, `OutputType WinExe`), legacy non-SDK csproj (MSBuild ToolsVersion 15.0) with `packages.config`.
- **UI:** Windows Forms (WinForms), with WPF-style XAML resources used only for some icon files.
- **NuGet packages:**
  - EntityFramework **6.3.0**
  - HtmlAgilityPack **1.8.1** (Book Depository page scraping)
  - Stub.System.Data.SQLite.Core.NetFramework **1.0.113.3**
  - System.Data.SQLite **1.0.113.7** (+ Core, EF6, Linq providers)
- **Database:** SQLite via the EF6 SQLite provider; schema created by `BookKeeperDatabase.db` (committed) or re-created at runtime through direct SQL in `Utilities.Database`.
- **Build tools:** Visual Studio 2017+ (solution format VS15) / MSBuild; NuGet restore for `packages.config`.

## Build & run instructions

This is a classic .NET Framework project (not SDK-style), so it is built with **MSBuild** rather than `dotnet build`:

```bat
nuget restore BookKeeper.sln
msbuild BookKeeper.sln /p:Configuration=Debug /p:Platform="Any CPU"
```

or simply open `BookKeeper.sln` in **Visual Studio 2017/2019** and build/run (F5). The output executable is `bin\Debug\BookKeeper.exe`.

There is no CLI/`dotnet run` support in the project file. The csproj pre-build event force-kills a running `BookKeeper.exe` before each build.

## Usage notes / configuration

- **No app configuration is required** – `Properties/Settings.settings` is empty and `App.config` only registers the EF6/SQLite providers.
- On startup the app creates the folders `Data`, `Cache`, and `Reports` if they don't exist.
- **Database:** the SQLite file `BookKeeperDatabase.db` is copied to the output directory (`CopyToOutputDirectory=PreserveNewest`). The `Utilities.Database` class issues raw SQL against tables `Books` and `Loans` (columns: title/author/description/category/quantity/image/ID, and loaner name/loan date/return date/book ID). If the database file is missing, the dashboard shows "Database file does not exist!".
- **Book Depository scraping** requires internet access and targets `bookdepository.com`; it uses HtmlAgilityPack selectors for `h1` (title), `itemprop="author"` spans, the `item-excerpt trunc` description block and the `item-img-content` image URL.
- **Search** normalizes input (uppercase, removes punctuation/double spaces) before matching.
- Book IDs are randomly generated (`1000000–10000000`) when saving a new book.
- On exit the app confirms before closing and serializes the current book list to `Data/books.bin` for faster startup.
- **Development aids:** `CustomAttributes.cs` defines `[NotWorkingCorrectly]`, `[NeedsPerformanceImprovement]`, `[Incomplete]`, and `[LengthCanBeImproved]` attributes, which emit compiler warnings in Release builds.

## License

No `LICENSE` file is present in the repository. (The About dialog identifies the author as George Mihăilă, © 2018, and links to https://github.com/georgemihaila.)
