# Installation

Dans un premier temps, il faut installer les dépendances nécessaires

```bash
dotnet tool install --global dotnet-ef
```

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.2
dotnet add package Microsoft.EntityFrameworkCore.Relational --version 8.0.2
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
dotnet add package Microsoft.AspNetCore.OpenApi --version 8.0.10
```

### Base de données

Pour mettre en place la base de donénes, il faut exécuter la commande suivante

```bash
dotnet ef database update
```

### .env

Pour configurer le `.env` il faut se réferrer au `.env.example`. Il suffit de copier les variables dans ce fichier et y ajouter les valeurs de votre choix

**Attention !** Dans votre `.env` il faut impérativement que l'`API_KEY` concorde avec votre projet front-end.