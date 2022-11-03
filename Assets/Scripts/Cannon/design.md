# Design Note

## Component Relationships

```mermaid

classDiagram

  GameSystem --> UIManager
  GameSystem --> AudioManager
  GameSystem --> GameManager

  GameManager --> Cannon
  GameManager --> Sprinkler
  GameManager --> PowerupItem01
  GameManager --> ItemObject02

  Cannon --> IFireTiming
  Cannon --> IControllerManager
  Cannon --> IPaint

  IFireTiming <|-- FireTiming
  IControllerManager <|-- JoyconController
  IPaint <|-- BulletPaint

  Sprinkler --> IPaint

```
