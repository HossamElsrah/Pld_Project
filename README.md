### Grammar Specification Overview

This file defines a simple programming language grammar using Backus-Naur Form (BNF) notation. The language outlines the structure of programs, statements, and various constructs like assignments, conditionals, loops, and functions.

- **Start Symbol**: The grammar begins with `<program>`, which represents the entry point of any program.
- **Terminal Symbols**: 
  - `Id`: Represents identifiers (e.g., variables) starting with `_` or a letter, followed by letters, numbers, or `_`.
  - `Digit`: Represents numbers, optionally with a sign (+/-) and decimal points (e.g., 3.14).
- **Key Rules**:
  - A `<program>` is enclosed between `begin` and `end`, containing a sequence of `<statements>`.
  - `<statements>` can be a single `<concept>` or multiple `<concept>`s.
  - `<concept>` includes `<assign>` (e.g., `<id> = <expr>`), `<if_stmt>` (with `if` and `then` blocks), `<loop_stmt>` (a loop with initialization and step), `<while_stmt>` (a while loop), and function definitions/calls.
  - Expressions (`<expr>`) support addition and subtraction, with `<term>` and `<factor>` handling multiplication, division, and exponentiation.
  - Functions are defined with `<function_def>` and called with `<function_call>`, supporting parameters and return types like `int`, `float`, etc.

This grammar is designed to be parsed with tools like ANTLR. Save it as a `.g4` file, set `<program>` as the start symbol, and generate the parser to use it.
