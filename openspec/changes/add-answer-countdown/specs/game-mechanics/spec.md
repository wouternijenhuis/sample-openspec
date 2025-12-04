## ADDED Requirements

### Requirement: Answer Countdown Timer
The system SHALL display a countdown timer before showing answer options to give players time to think about the answer.

#### Scenario: Countdown starts when question appears
- **WHEN** a new question is displayed
- **THEN** a visual countdown timer SHALL begin at 3 seconds
- **AND** the answer options SHALL be hidden

#### Scenario: Countdown visual feedback
- **WHEN** the countdown is active
- **THEN** the remaining seconds SHALL be displayed prominently
- **AND** the question text SHALL remain visible

#### Scenario: Answers appear after countdown
- **WHEN** the countdown reaches zero
- **THEN** the answer options SHALL become visible
- **AND** the player MAY select an answer

#### Scenario: Countdown applies to all game types
- **WHEN** playing the Arithmetic game
- **THEN** the countdown timer SHALL be active
- **WHEN** playing the Topography game
- **THEN** the countdown timer SHALL be active
