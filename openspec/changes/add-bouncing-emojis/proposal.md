# Change: Add fun bouncing emojis throughout the site

## Why
The application is designed for children and should feel playful and celebratory. Adding animated bouncing emojis throughout the site will make the experience more engaging, fun, and visually appealing for young learners.

## What Changes
- Add bouncing emoji decorations to navigation menu items
- Add animated emojis to page titles and headings
- Add celebratory emojis to buttons and interactive elements
- Add emoji animations to loading states and transitions
- Add floating/bouncing background emojis on game pages
- Create reusable CSS animation classes for emoji effects
- Use fun/celebration themed emojis (🎉 ⭐ 🌟 🎈 🎊 ✨ 🏆 💫 🌈 🦋 🚀)

## Impact
- Affected specs: `ui-enhancements` (new capability)
- Affected code:
  - `LeesSom.Client/wwwroot/css/app.css` - new emoji animation styles
  - `LeesSom.Client/Features/Home/Home.razor` - home page emojis
  - `LeesSom.Client/Features/Games/Arithmetic/ArithmeticGame.razor` - game page emojis
  - `LeesSom.Client/Features/Games/Topography/TopographyGame.razor` - game page emojis
  - `LeesSom.Client/Layout/NavMenu.razor` - navigation emojis
  - `LeesSom.Client/Layout/MainLayout.razor` - layout-wide decorations
