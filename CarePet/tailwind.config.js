/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.{html,cshtml}",
    "./wwwroot/**/*.{html,js}",
  ],
  theme: {
    extend: {
      colors: {
        'dark-bg': '#0A0A0A',
        'primary-blue': '#2979FF',
        'primary-pink': '#FF80AB',
        'primary-orange': '#FF6D00',
        'primary-yellow': '#FFD600',
        'primary-green': '#00E676',
        'primary-purple': '#3D5AFE',
      },
      backdropBlur: {
        'xs': '2px',
      },
      animation: {
        'gradient': 'gradient 8s ease infinite',
        'float': 'float 6s ease-in-out infinite',
      },
      keyframes: {
        gradient: {
          '0%, 100%': {
            'background-size': '200% 200%',
            'background-position': 'left center'
          },
          '50%': {
            'background-size': '200% 200%',
            'background-position': 'right center'
          }
        },
        float: {
          '0%, 100%': { transform: 'translateY(0px)' },
          '50%': { transform: 'translateY(-20px)' }
        }
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
} 