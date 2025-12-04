# OpenSpec Workflow Guide

This project uses **OpenSpec** for spec-driven development. This document explains how to work with specifications and change proposals.

## What is OpenSpec?

OpenSpec is a specification-first approach to development where:

- **Specs** define what IS built (the truth)
- **Changes** propose what SHOULD change (proposals)
- All significant changes go through a proposal → approval → implementation workflow

## When to Create a Proposal

### ✅ Create a Proposal For:
- New features or capabilities
- Breaking changes (API, schema, behavior)
- Architecture changes
- Performance optimizations that change behavior
- Security pattern changes

### ❌ Skip Proposal For:
- Bug fixes (restoring intended behavior)
- Typos, formatting, comments
- Non-breaking dependency updates
- Configuration changes
- Tests for existing behavior

## Quick Commands

```bash
# List active change proposals
openspec list

# List existing specifications
openspec list --specs

# View a specific change or spec
openspec show [item]

# Validate a change proposal
openspec validate [change-id] --strict

# Archive a completed change
openspec archive [change-id] --yes
```

## Creating a Change Proposal

### Step 1: Check Existing Work

```bash
# See what's already proposed
openspec list

# See existing specifications
openspec list --specs

# Search for related content
rg "keyword" openspec/
```

### Step 2: Create the Proposal Structure

```bash
# Create directory
mkdir -p openspec/changes/add-my-feature/specs/my-capability

# Create required files
touch openspec/changes/add-my-feature/proposal.md
touch openspec/changes/add-my-feature/tasks.md
touch openspec/changes/add-my-feature/specs/my-capability/spec.md
```

### Step 3: Write proposal.md

```markdown
# Change: Add My Feature

## Why
Brief explanation of the problem or opportunity.

## What Changes
- List of changes
- Mark **BREAKING** changes clearly

## Impact
- Affected specs: [list capabilities]
- Affected code: [key files/areas]
```

### Step 4: Write Spec Deltas

Use these section headers in `specs/[capability]/spec.md`:

```markdown
## ADDED Requirements
### Requirement: New Feature Name
The system SHALL provide [capability].

#### Scenario: Success case
- **WHEN** user does something
- **THEN** expected result occurs

## MODIFIED Requirements
### Requirement: Existing Feature
[Complete updated requirement text]

## REMOVED Requirements
### Requirement: Old Feature
**Reason**: Why it's being removed
**Migration**: How to handle existing usage
```

### Step 5: Write tasks.md

```markdown
## 1. Implementation
- [ ] 1.1 Create database schema
- [ ] 1.2 Implement API endpoint
- [ ] 1.3 Add frontend component

## 2. Testing
- [ ] 2.1 Write unit tests
- [ ] 2.2 Manual verification
```

### Step 6: Validate

```bash
openspec validate add-my-feature --strict
```

## Implementing Changes

1. **Read** `proposal.md` - Understand the why and what
2. **Read** `design.md` (if exists) - Review technical decisions
3. **Follow** `tasks.md` - Complete tasks in order
4. **Update** `tasks.md` - Mark items `[x]` as completed
5. **Validate** - Run `openspec validate --strict`

## Directory Structure

```
openspec/
├── project.md              # Project conventions and context
├── AGENTS.md               # AI assistant instructions
├── specs/                  # Current truth - what IS built
│   └── [capability]/
│       └── spec.md
└── changes/                # Proposals - what SHOULD change
    ├── [change-name]/
    │   ├── proposal.md     # Why and what
    │   ├── tasks.md        # Implementation checklist
    │   ├── design.md       # Technical decisions (optional)
    │   └── specs/          # Delta specifications
    │       └── [capability]/
    │           └── spec.md
    └── archive/            # Completed changes
```

## Best Practices

### Naming Conventions

- **Change IDs**: kebab-case, verb-led
  - `add-user-authentication`
  - `update-score-algorithm`
  - `remove-legacy-api`
  - `refactor-data-layer`

- **Capability names**: noun-based
  - `user-auth`
  - `game-mechanics`
  - `ui-enhancements`

### Writing Requirements

- Use **SHALL** or **MUST** for normative requirements
- Every requirement needs at least one `#### Scenario:`
- Keep scenarios focused and testable

### Scenario Format

```markdown
#### Scenario: Descriptive name
- **WHEN** specific action or condition
- **THEN** expected outcome
```

## Working with AI Assistants

When asking AI assistants to make changes:

1. **For new features**: Say "Create an OpenSpec proposal for..."
2. **For implementation**: Say "Implement the [change-id] proposal"
3. **For bug fixes**: Can proceed directly without proposal

The AI will:
- Check existing specs and proposals
- Create proper proposal structure
- Validate before implementation
- Update tasks as completed

## Example Workflow

```bash
# 1. User asks for new feature
"I want to add user profiles"

# 2. AI creates proposal
openspec/changes/add-user-profiles/
├── proposal.md
├── tasks.md
└── specs/user-management/spec.md

# 3. Validate
openspec validate add-user-profiles --strict

# 4. After approval, implement
# (AI follows tasks.md, marks items complete)

# 5. After deployment, archive
openspec archive add-user-profiles --yes
```

## More Information

- See `openspec/AGENTS.md` for detailed AI instructions
- See `openspec/project.md` for project-specific conventions
- Run `openspec --help` for all CLI commands
