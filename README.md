## The Final Battle
A basic console RPG game.

## Features
- Load your own levels in a JSON file.

## Features to add
- Selection of character.
- XP
- Temporary effects

## How to load your own levels?
1. Create a JSON file in \TheFinalBattle\bin\Debug\net8.0
2. The next structure is for the creation of one level. You can leave idGear and idDefensiveModifier as null.
```json
[
  {
    "partyEnemy": {
      "inventory": [
        {
          "id": 1,
          "amount": 2
        }
      ],
      "enemies": [
        {
          "id": 2,
          "idGear": 3,
          "idDefensiveModifier": 1
        }
      ]
    },
    "rewards": [
      {
        "id": 1,
        "amount": 1
      }
    ]
  },
]
```
3. When the game asks you about if you want to load your own levels, enter y and then enter your filename
<img width="417" height="52" alt="image" src="https://github.com/user-attachments/assets/7d98aac1-a4ea-4089-9aff-08b28bb32b82" />

4. The program will tell you which levels are valid
<img width="570" height="192" alt="image" src="https://github.com/user-attachments/assets/2ae8f64e-c2c6-43c4-ad76-bdacaf86ac55" />

## List of Items
| Id | Name  |
| -- | --- |
| 1 | Medicine |

## List of Gear
| Id | Name  |
| -- | --- |
| 2 | Debugger |
| 3 | Glass Knife |
| 4 | Ice Staff |

## List of Entities
| Id | Name  |
| -- | --- |
| 1 | Vin |
| 2 | Skeleton |
| 3 | Archer |
| 4 | Fairy |
| 5 | Undefined |
| 6 | Firehog |
| 7 | The Uncoded One |

## List of Attack Modifiers
| Id | Name  |
| -- | --- |
| 1 | Atium |
| 2 | Object Sight |
| 3 | Frost Cape |
| 4 | Magma Stone |

