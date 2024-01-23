# Assignment Test Data

In this file you can find predefined test cases for validation application correctness work

## Basic variant:

In this section you can find test cases for the basic step, when we don't work with negative numbers, brackets and power
operator

    // | Input:         3 + 4 - 8 + 9
    // | Tokenization:  ["3", "+", "4", "-", "8", "+", "9"]
    // | Shunting:      ["3 4 + 8 - 9 +"]
    // | Evaluation:    8

    // | Input:         23 - 34 + 99 - 18
    // | Tokenization:  ["23", "-", "34", "+", "99", "-", "18"]
    // | Shunting:      ["23", "34", "-", "99", "+", "18", "-"]
    // | Evaluation:    70