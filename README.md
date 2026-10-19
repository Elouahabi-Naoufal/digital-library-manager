<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a id="readme-top"></a>

<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT TITLE -->
<br />
<div align="center">
  <h3 align="center">Digital Library Manager</h3>

  <p align="center">
    A console library manager in C#: books, magazines and PDF documents with search, deletion and
    CSV persistence.
    <br />
    <a href="https://github.com/Elouahabi-Naoufal/digital-library-manager"><strong>Explore the repository »</strong></a>
    <br />
    <br />
    <a href="https://github.com/Elouahabi-Naoufal/digital-library-manager/issues">Report Bug</a>
    &middot;
    <a href="https://github.com/Elouahabi-Naoufal/digital-library-manager/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

Digital Library Manager is a small .NET console application built around an abstract `Document`
type and three concrete subclasses: `Livre` (book, with page count), `Magazine` (with issue number)
and `DocumentPDF` (with file size in MB). The `Bibliotheque` class owns the collection and exposes
add, search, delete, save and load operations.

The menu covers seven actions:

1. Add a document (book, magazine or PDF)
2. Display every document
3. Search by keyword in title or author
4. Delete a document by its GUID
5. Save the library to a file
6. Load a library from a file
7. Quit

Persistence is a semicolon-separated text format, one document per line:

```text
Livre;<GUID>;<Titre>;<Auteur>;<Annee>;<NombrePages>
Magazine;<GUID>;<Titre>;<Auteur>;<Annee>;<Numero>
DocumentPDF;<GUID>;<Titre>;<Auteur>;<Annee>;<TailleEnMo>
```

Missing documents raise the custom `DocumentNonTrouveException`. File access is wrapped in
`try`/`catch` and streams are disposed with `using`. The UI and messages are in French. There is no
graphical interface, database or network access.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* [![C#][csharp-shield]][csharp-url]
* [![.NET][dotnet-shield]][dotnet-url] — `net9.0`

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

* .NET SDK 9.0 or newer
  ```sh
  dotnet --version
  ```
* A terminal. No external packages are required.

### Installation

1. Clone the repository
   ```sh
   git clone https://github.com/Elouahabi-Naoufal/digital-library-manager.git
   cd digital-library-manager
   ```
2. Build
   ```sh
   dotnet build
   ```
3. Run
   ```sh
   dotnet run
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE -->
## Usage

Start the app and pick a menu number. A typical session:

1. Choose `1` and add a `Livre` with title, author, year and page count.
2. Add a `Magazine` or `DocumentPDF` the same way.
3. Choose `2` to list everything, including each document's GUID.
4. Choose `3` and enter a keyword to search titles and authors.
5. Choose `5` and enter a filename to save; `testing.txt` in the repository is an example export.
6. Choose `6` and enter the saved filename to reload it. Loading clears the current in-memory
   collection first.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ROADMAP -->
## Roadmap

- [x] Abstract document model with three concrete types
- [x] Add, list, search, delete, save and load
- [x] Custom not-found exception and file error handling
- [ ] Escape semicolons in titles/authors so CSV round-trips safely
- [ ] Validate numeric input instead of letting `int.Parse` throw
- [ ] Add unit tests for save/load and search
- [ ] Add an optional JSON export alongside the legacy CSV format

See the [open issues](https://github.com/Elouahabi-Naoufal/digital-library-manager/issues) for a full list of proposed features and known issues.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Top contributors:

<a href="https://github.com/Elouahabi-Naoufal/digital-library-manager/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=Elouahabi-Naoufal/digital-library-manager" alt="contrib.rocks image" />
</a>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

No `LICENSE` file is bundled with this repository. This project is not licensed — all rights reserved.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Naoufal Elouahabi
* LinkedIn: [https://www.linkedin.com/in/elouahabi-naoufal/](https://www.linkedin.com/in/elouahabi-naoufal/)
* Email: [elouahabi-naoufal1@gmail.com](mailto:elouahabi-naoufal1@gmail.com)

Project Link: [https://github.com/Elouahabi-Naoufal/digital-library-manager](https://github.com/Elouahabi-Naoufal/digital-library-manager)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [.NET documentation](https://learn.microsoft.com/dotnet/)
* [C# programming guide](https://learn.microsoft.com/dotnet/csharp/)
* [Best-README-Template](https://github.com/othneildrew/Best-README-Template)
* [Img Shields](https://shields.io)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/Elouahabi-Naoufal/digital-library-manager.svg?style=for-the-badge
[contributors-url]: https://github.com/Elouahabi-Naoufal/digital-library-manager/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Elouahabi-Naoufal/digital-library-manager.svg?style=for-the-badge
[forks-url]: https://github.com/Elouahabi-Naoufal/digital-library-manager/network/members
[stars-shield]: https://img.shields.io/github/stars/Elouahabi-Naoufal/digital-library-manager.svg?style=for-the-badge
[stars-url]: https://github.com/Elouahabi-Naoufal/digital-library-manager/stargazers
[issues-shield]: https://img.shields.io/github/issues/Elouahabi-Naoufal/digital-library-manager.svg?style=for-the-badge
[issues-url]: https://github.com/Elouahabi-Naoufal/digital-library-manager/issues
[license-shield]: https://img.shields.io/badge/License-All%20rights%20reserved-red.svg?style=for-the-badge
[license-url]: https://github.com/Elouahabi-Naoufal/digital-library-manager
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/elouahabi-naoufal/
[csharp-shield]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white
[csharp-url]: https://learn.microsoft.com/dotnet/csharp/
[dotnet-shield]: https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[dotnet-url]: https://dotnet.microsoft.com/
