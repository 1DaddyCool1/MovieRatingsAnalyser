# 🎬 MovieRatingsAnalyser

MovieRatingsAnalyser is a C#/.NET application for analyzing and processing movie rating data.

This project demonstrates backend logic, clean architecture principles, object-oriented programming, and data processing skills. It was built as a practical project to strengthen my backend development abilities.

---

# 📌 Project Overview

The application processes a dataset of movies and their ratings, performs statistical analysis, and outputs structured results.

It focuses on:

- Clean and maintainable code
- Logical separation of responsibilities
- Data processing and sorting
- Backend-focused problem solving

---

# 🏗 Architecture

The project follows a simple layered structure:

```
MovieRatingsAnalyser/
│
├── Models/        # Data models (Movie, Rating, etc.)
├── Services/      # Business logic and data processing
├── Program.cs     # Application entry point
└── Movie.sln      # Solution file
```

### Layers Explanation

- **Models** → Represent the data structure
- **Services** → Contain business logic and calculations
- **Program** → Handles application execution flow

This separation improves readability, scalability, and maintainability.

---

# 🚀 Features

- Load movie rating data
- Calculate average rating per movie
- Identify top-rated movies
- Sort movies (ascending / descending)
- Display structured results
- Modular and extensible codebase

---

# 🧠 Technical Skills Demonstrated

- C# and .NET development
- Object-Oriented Programming (OOP)
- Collections and LINQ
- Data filtering and sorting
- Clean code principles
- Basic architectural thinking
- Problem-solving skills

---

# 💻 Example Code Snippets

Example of calculating average rating:

```csharp
public double CalculateAverageRating(List<double> ratings)
{
    if (ratings == null || ratings.Count == 0)
        return 0;
    return ratings.Average();
}
```

Example of sorting movies by rating:

```csharp
var sortedMovies = movies
    .OrderByDescending(m => m.AverageRating)
    .ToList();
```

---

# 📦 Installation & Running

1. **Clone the repository**
   ```bash
   git clone https://github.com/1DaddyCool1/MovieRatingsAnalyser.git
   ```

2. **Open in Visual Studio**
   Open `Movie.sln`

3. **Build & Run**
   Press F5 or click Start

---

# 📈 Example Use Case

The application:

- Reads movie rating data
- Calculates average score
- Sorts movies by rating
- Displays top-performing movies

This simulates basic backend data analysis logic used in real-world systems.

---

# 🔮 Future Improvements

- Add database integration (SQL Server / PostgreSQL)
- Convert to REST API (ASP.NET Core)
- Add unit testing (xUnit / NUnit)
- Implement dependency injection
- Add logging
- Docker support

---

# 👨‍💻 For Recruiters

This project demonstrates:

- Strong Junior-level backend skills
- Understanding of OOP and code structure
- Ability to write clean and readable code
- Practical experience with C#/.NET
- Readiness to work in backend development environments

**I am actively seeking a Junior Backend Developer position**
*(Java Backend or C#/.NET)*

Open to work 🚀

---

# 👤 Author

- **GitHub:** https://github.com/1DaddyCool1
- **Title:** Junior Software Developer
- **Skills:** Java Backend | C#/.NET
- **Status:** Open to work 🚀

