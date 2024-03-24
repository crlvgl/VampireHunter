# Game Controls

## Controller

_Note: all Buttons refer to a Xbox GamePad_

### Standard

_references and own mapping_

| **Button**        | **Hunt the Night**                               | **Acane**                     | **our game**      |
| ----------------- | ------------------------------------------------ | ----------------------------- | ----------------- |
| Left Stick        | Move                                             | Move                          | Move              |
| Right Stick       | Aim                                              | -                             |                   |
| A                 | (Menu) Submit<br/>Dash                           | Defend                        | Sprint            |
| B                 | Special Attack                                   | Attack <br/>when aimed, shoot | continue Dialogue |
| X                 | Attack<br/>(when Umbra) Teleport<br/>Interaction | -                             |                   |
| Y                 | Summon Umbra (Help)<br/>Interact                 | Special Move                  |                   |
| Dpad Up           | (Menu) Up<br/>Healing Item                       | -                             |                   |
| Dpad Down         | (Menu) Down<br/>Special Ability                  | -                             |                   |
| Dpad Left         | (Menu) Left                                      | -                             |                   |
| Dpad Right        | (Menu) Right                                     | -                             |                   |
| Start / +         |                                                  | -                             |                   |
| Menu / -          | Pause <br/>Return Menu<br/>Skip Text             | -                             |                   |
| Left Shoulder     | previous ranged Weapon<br/>Menu Left             | Dash                          | Dash              |
| Left Shoulder 2.  | Throw                                            | Aim                           |                   |
| Right Shoulder    | next ranged Weapon<br/>Menu Right                | Special Attack 1              |                   |
| Right Shoulder 2. | Shoot                                            | Special Attack 2              |                   |

### Special

| Button | **Hunt the Night** | **Acane**      | **our game** |
| ------ | ------------------ | -------------- | ------------ |
| Hold A |                    | Charged Attack |              |

______

# Keyboard / Mouse Controls

| Action       | Function   |
| ------------ | ---------- |
| W            | Move up    |
| A            | Move left  |
| S            | Move Down  |
| D            | Move Right |
| Left Shift   | Sprint     |
| Left Control | Evade      |
| Left Alt     | Walk       |

[Unity - Input Manager / Button Mapping](https://docs.unity3d.com/Manual/class-InputManager.html)

______

## Unity Controller Button Mapping

| **Shortcut** | **Controller Button Name**   | **Mapping in Unity / Windows** | **Mapping in Unity / MacOS** | **Return Value** |
| ------------ | ---------------------------- | ------------------------------ | ---------------------------- | ---------------- |
| A            | A                            | joystick button 0              | joystick button 16           | true             |
| B            | B                            | joystick button 1              | joystick button 17           | true             |
| X            | X                            | joystick button 2              | joystick button 18           | true             |
| Y            | Y                            | joystick button 3              | joystick button 19           | true             |
| LB           | Left Bumper                  | joystick button 4              | joystick button 13           | true             |
| RB           | Right Bumper                 | joystick button 5              | joystick button14            | true             |
| LT           | Left Trigger                 | 9th Axis                       | 5th Axis                     | 0 to 1           |
| LT           | Left Trigger Shared Axis     | 3rd Axis                       | -                            | 0 to 1           |
| RT           | Right Trigger                | 10th Axis                      | 6th Axis                     | 0 to 1           |
| RT           | Right Trigger Shared Axis    | 3rd Axis                       | -                            | 0 to -1          |
| Back         | View (Back)                  | joystick button 6              | joystick button 10           | true             |
| Start        | Menu (Start)                 | joystick button 7              | joystick button 9            | true             |
| LS_h         | Left Stick "Horizontal"      | X Axis                         | X Axis                       | -1 to 1          |
| LS_v         | Left Stick "Vertical"        | Y Axis                         | Y Axis                       | -1 to 1          |
| LT_B         | Left Stick Button            | joystick button 8              | joystick button 11           | true             |
| RS_h         | Right Stick "HorizontalTurn" | 4th Axis                       | 3rd Axis                     | -1 to 1          |
| RS_v         | Right Stick "VerticalTurn"   | 5th Axis                       | 4th Axis                     | -1 to 1          |
| RS_B         | Right Stick Button           | joystick button 9              | joystick button 12           | true             |
| DPAD_h       | DPAD - Horizontal            | 6th Axis                       | -                            | -1 (.64) 1       |
| DPAD_v       | DPAD - Vertical              | 7th Axis                       | -                            | -1 (.64) 1       |
| DPAD_up      | DPAD - up                    | -                              | joystick button 5            | true             |
| DPAD_down    | DPAD - down                  | -                              | joystick button 6            | true             |
| DPAD_left    | DPAD - left                  | -                              | joystick button 7            | true             |
| DPAD_right   | DPAD - right                 | -                              | joystick button 8            | true             |

[Picture of Button Mapping](https://europe1.discourse-cdn.com/unity/original/3X/c/3/c30679da812a1fdfd9521741f28fd88e71347a5b.jpeg)
