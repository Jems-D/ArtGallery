# ArtGallery

Repository for app gallery
Harvard Arts Explorer is an interactive web application that allows users to browse, search, and favorite artworks from the Harvard Art Museums. It also fetches real-time art-related news using the **Current News API**. Built with **React (TypeScript)** on the frontend and **ASP.NET Core Web API** on the backend, with **JWT authentication** for secure access.

---

## 🎨 Features

- 🔍 **Search Artworks**  
  Search the Harvard Art Museums collection using keywords (artist, title, medium, etc.).

- 🧩 **Filter by Category**  
  Refine results based on culture, classification, or other metadata.

- ⭐ **Favorites System**  
  Add and remove artworks from a personalized favorites list.

- 🖊️ **Review system**
  Add and remove review to artworks

- 📰 **Live Art News**  
  Fetch the latest art-related headlines using the **Current News API**.

- 🔐 **Secure Authentication**
  - JWT-based authentication
  - HTTP-only cookie storage
  - Protected routes and auto-refresh

---

## 🧰 Tech Stack

### Frontend

- React + TypeScript
- Vite
- Tailwind
- React Router DOM (Data)
- Axios
- React Hook Forms + resolver + yup

### Backend

- ASP.NET Core Web API
- Entity Framework Core
- JWT Auth (access & refresh tokens)
- RESTful architecture

### APIs Used

- 🎨 [Harvard Art Museums API](https://github.com/harvardartmuseums/api-docs)
- 📰 [Current News API](https://currentsapi.services/en/docs/)

🔒To keep API keys and sensitive config values secure, this project uses environment variables.
This project uses **environment variables** to manage all sensitive data such as API keys, endpoints, and secrets. No credentials are hardcoded in the codebase. This ensures a secure and maintainable approach for both development and production environments.

## ⚙️ Frontend (React + Vite)

Environment variables are stored in a `.env` file located at the root of the frontend (`/frontend`) directory.
You will have to create a .env for it to work

### Example `.env` file:

```env
 Base URL of the ASP.NET Core Web API
VITE_API_URL_AUTH_ENDPOINT=http://localhost:5000/api/Auth
VITE_API_URL_NEWS_ENDPOINT=http://localhost:5000/api/news
VITE_API_URL_MUSUEM_ENDPOINT=http://localhost:5000/api/search
VITE_API_URL_MUSUEM_REVIEW_ENDPOINT=http://localhost:5000/api/review
VITE_API_URL_MUSUEM_FAVORITE_ENDPOINT=http://localhost:5000/api/favourites

```

# 🔐 ASP.NET Core Environment Variable Configuration

This project uses **environment variables** to securely manage sensitive information such as:

- API keys (e.g., Harvard Art Museum API, Currents News API)

Environment variables are stored at root of the api ('/api') directory

No secrets are hardcoded in code or checked into version control.

```env
HARVARD_MUSEUM_API_KEY=apikey
HARVARD_MUSEUM_API_KEY=apikey
```

The connection string and the JWT, signing key, issuer, and audience, are also not hardcoded, but a template is provided in ## appsettings.Development.json ##

You will have to create a appsettings.json file for it to work
