# Assignment Test Data

In this file you can find predefined test cases for validation application correctness work

## Basic Implementation:

    // | Input:         3 + 4 - 8 + 9
    // | Tokenization:  ["3", "+", "4", "-", "8", "+", "9"]
    // | Shunting:      ["3", "4", "+", "8", "-", "9", "+"]
    // | Evaluation:    8

    // | Input:         23 - 34 + 99 - 18
    // | Tokenization:  ["23", "-", "34", "+", "99", "-", "18"]
    // | Shunting:      ["23", "34", "-", "99", "+", "18", "-"]
    // | Evaluation:    70

    // | Input:         10.65+3.65
    // | Tokenization:  ["10.65", "+", "3.65"]
    // | Shunting:      ["10.65", "3.65", "+"]
    // | Evaluation:    14.3

## Negative Numbers

    // | Input:         10 + -3
    // | Tokenization:  ["10", "+", "-3"]
    // | Shunting:      ["10", "-3", "+"]
    // | Evaluation:    7

    // | Input:         -10 + -3
    // | Tokenization:  ["-10", "+", "-3"]
    // | Shunting:      ["-10", "-3", "+"]
    // | Evaluation:    -13

## Brackets

    // | Input:         (2 + 5 * 8) * (4 - 2 / 9)
    // | Tokenization:  ["(", "2", "+", "5", "*", "8", ")", "*", "(", "4", "-", "2", "/", "9", ")"]
    // | Shunting:      ["2", "5", "8", "*", "+", "4", "2", "9", "/", "-", "*"]
    // | Evaluation:    158.6(6)

## Power Operator

    // | Input:         (2^10 + (9 + 6^2)) ^ 3
    // | Tokenization:  ["(", "(", "2", "^", "10", "+", "(", "9", "+", "6", "^", "2", ")", ")", "^", "3"]
    // | Shunting:      ["2", "10", "^", "9", "+", "6", "2", "^", "+", "3", "^"]
    // | Evaluation:    1221611509


