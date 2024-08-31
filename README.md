# Memento Design Pattern
It is a behavioural design pattern used to capture and restore the internal state of an object without exposing it's implementation details.

## Memento Design Pattern consist of following componenets

### 1. Originator
This is the class whose state you want to save and restore.
### 2. Memento
This class stores the state of the Originator.
### 3. Caretaker
This class is responsible for storing and restoring Memento objects. It keeps a history of the states so the user can undo or redo their changes.

## About the project
The following project is a simple Text Editor that displays the most recent text entered by the user, the user can undo (to get back to the previous state if exists) or redo (to get the next state if exists).
- TextEditor : This is the originator class
- Memento : Stores the state of TextEditor
- Caretaker : Keeps history of the states
