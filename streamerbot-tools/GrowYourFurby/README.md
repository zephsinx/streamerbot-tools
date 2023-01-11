# Grow Your Furby

## Table of Contents

- [Setup Instructions](#setup-instructions)
- [Actions](#actions)
  - [Furby Setup](#furby-setup)
  - [Grow Your Furby](#grow-your-furby-1)
  - [Set Furby Length](#set-furby-length)
  - [Add/Subtract Furby Inches](#addsubtract-furby-inches)

## Setup Instructions

- Copy the import string from the [Import File](GrowYourFurbyImport.txt)
- Click the Import button on Streamer.bot
- Select which actions and commands to import
- Make sure to set a path to the file that will hold the furby counts

## Actions

### Furby Setup

#### Description

> Note: It is important to set the value of `global_furbyFilePath` to ensure all other actions know what file to use to store their information.

- Sets the global variable `global_furbyFilePath` used by other actions.
- `global_furbyFilePath` represents the path to the file where all furby counts are stored.

#### Usage

- Use bundled `!initfurby` command or create new command with `Furby Setup` action.

### Grow Your Furby

#### Description

- Adds 1 inch to a user's furby length each time it redeemed.
- Intended to only be redeemable once per stream.

#### Usage

- Attach `Grow Your Furby` action to channel point redeem.
- Set max number of redeems per user per stream to 1 (or desired amount)

#### Result

- Message sent to Twitch chat: `some_username's furby is now 5 inches long!`
  - Where `some_username` is the name of the redeeming user.
  - Where `5` is the total number of inches so far.

### Set Furby Length

#### Description

- Sets specified user's furby length to the specified amount.
- Value must be 0 or greater.

#### Usage

- Use bundled `!setfurby` command or create new command with `Set Furby Length` action.
- Call command in chat.
  - e.g. To set the furby length to 25 inches for a user named `some_username`:
    - `!setfurby some_username 25`

#### Result

- Message sent to Twitch chat: `some_username's furby is now 25 inches long!`
    - Where `some_username` is the name of the user provided after the command.
    - Where `25` is the number of inches specified in the command.

### Add/Subtract Furby Inches

#### Description

- Adds or subtracts the specified number of inches from the specified user's furby length.
- Supports both positive and negative numbers.
- Final value must be 0 or greater.
- If user does not exist, they are inserted to the list with the specified number of inches.

#### Usage

- Use bundled `!addfurby` command or create new command with `Add/Subtract Furby Inches` action.
- Call command in chat.
  - e.g. To add 5 inches to the furby length of a user named `some_username`:
    - `!addfurby some_username 5`
  - e.g. To subtract 5 inches to the furby length of a user named `some_username`:
      - `!addfurby some_username -5`

#### Result

- Message sent to Twitch chat: `some_username's furby is now 7 inches long!`
    - Where `some_username` is the name of the user provided after the command.
    - Where `7` is the number of inches after adding/subtracting total inches.
