# CarePet - Pet Care & Adoption Website

A modern, responsive pet care and adoption website built with .NET MVC, featuring a stunning Glassmorphism design and animated gradient backgrounds.

## 🌟 Features

### Design & UI
- **Glassmorphism Design**: Modern glass-like UI elements with blur effects
- **Animated Gradient Background**: Dynamic, breathing gradient background
- **Responsive Design**: Optimized for both mobile and desktop devices
- **Sharp Modern Styling**: Clean, contemporary design with smooth animations
- **Custom Color Palette**: Carefully selected colors for optimal visual appeal

### Functionality
- **Pet Adoption System**: Browse and filter available pets
- **Pet Care Services**: Comprehensive service listings with categories
- **Contact System**: Functional contact form with validation
- **Interactive Filtering**: Real-time pet and service filtering
- **Mobile-First Design**: Fully responsive across all devices

## 🎨 Color Palette

The website uses a carefully curated color palette:

- **Dark Background**: `#0A0A0A`
- **Primary Blue**: `#2979FF`
- **Primary Pink**: `#FF80AB`
- **Primary Orange**: `#FF6D00`
- **Primary Yellow**: `#FFD600`
- **Primary Green**: `#00E676`
- **Primary Purple**: `#3D5AFE`

## 🛠️ Technology Stack

- **.NET 8 MVC**: Backend framework
- **Tailwind CSS**: Utility-first CSS framework
- **Vanilla JavaScript**: For interactive features
- **Font Awesome**: Icon library
- **Google Fonts (Inter)**: Typography
- **No Database**: Uses in-memory data for demonstration

## 📁 Project Structure

```
CarePet/
├── Controllers/
│   └── HomeController.cs          # Main controller with all actions
├── Models/
│   ├── Pet.cs                     # Pet model
│   ├── CareService.cs             # Service model
│   └── Contact.cs                 # Contact form model
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Homepage
│   │   ├── Pets.cshtml            # Pet listings
│   │   ├── Services.cshtml        # Service listings
│   │   ├── About.cshtml           # About page
│   │   └── Contact.cshtml         # Contact page
│   └── Shared/
│       └── _Layout.cshtml         # Main layout
├── wwwroot/
│   ├── css/
│   │   ├── input.css              # Tailwind input file
│   │   └── output.css             # Compiled CSS
│   └── js/
│       └── animated-gradient-background.js  # Background animation
├── package.json                   # NPM dependencies
├── tailwind.config.js             # Tailwind configuration
└── README.md                      # This file
```

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK
- Node.js (for Tailwind CSS)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd CarePet
   ```

2. **Install NPM dependencies**
   ```bash
   npm install
   ```

3. **Build CSS**
   ```bash
   npx tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/output.css
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### Development

For development with CSS auto-compilation:
```bash
npx tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/output.css --watch
```

## 📱 Pages Overview

### 🏠 Homepage (`/`)
- Hero section with animated background
- Featured pets showcase
- Service overview
- Call-to-action sections

### 🐕 Pets Page (`/Pets`)
- Complete pet listings
- Advanced filtering (type, age, gender)
- Interactive pet cards
- Adoption information

### 🛠️ Services Page (`/Services`)
- Service categories and filtering
- Detailed service information
- Pricing plans
- Feature highlights

### ℹ️ About Page (`/About`)
- Company mission and values
- Team member profiles
- Statistics and achievements
- Certifications

### 📞 Contact Page (`/Contact`)
- Contact form with validation
- Contact information
- Emergency contact details
- FAQ section
- Social media links

## 🎯 Key Features

### Glassmorphism Effects
- Semi-transparent backgrounds
- Backdrop blur effects
- Subtle borders and shadows
- Layered visual hierarchy

### Animated Background
- Radial gradient animation
- Breathing effect
- Smooth color transitions
- Performance optimized

### Responsive Design
- Mobile-first approach
- Flexible grid layouts
- Touch-friendly interactions
- Optimized for all screen sizes

### Interactive Elements
- Hover animations
- Smooth transitions
- Form validation
- Dynamic filtering

## 🔧 Customization

### Colors
Edit `tailwind.config.js` to modify the color palette:

```javascript
colors: {
  'dark-bg': '#0A0A0A',
  'primary-blue': '#2979FF',
  // ... other colors
}
```

### Background Animation
Modify `wwwroot/js/animated-gradient-background.js` to customize:
- Animation speed
- Breathing range
- Gradient colors
- Animation behavior

### Styling
Add custom styles in `wwwroot/css/input.css`:
- Glassmorphism effects
- Custom animations
- Component styles

## 📄 License

This project is created for demonstration purposes. Feel free to use and modify as needed.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📞 Support

For questions or support, please contact the development team or create an issue in the repository.

---

**CarePet** - Connecting loving families with their perfect pet companions! 🐾 