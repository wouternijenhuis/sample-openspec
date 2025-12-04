# Change: Add countdown timer before answers are visible

## Why
Currently, answers appear immediately when a question is displayed, which doesn't give players time to think about the answer before seeing the options. Adding a countdown timer creates a "thinking period" that encourages players to formulate their own answer before multiple-choice options appear, improving the learning experience.

## What Changes
- Add a configurable countdown timer (default 3 seconds) before answer options become visible
- Display a visual countdown indicator while the timer is active
- Question text remains visible during the countdown
- Timer applies to both Arithmetic and Topography games
- Answer buttons are hidden (not just disabled) during countdown

## Impact
- Affected specs: `game-mechanics` (new capability)
- Affected code:
  - `LeesSom.Client/Pages/ArithmeticGame.razor`
  - `LeesSom.Client/Pages/TopographyGame.razor`
