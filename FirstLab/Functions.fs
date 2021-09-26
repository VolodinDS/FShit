namespace Functions

module HelpModule =
    let processNumber (number: int, procFunc: int -> int): int =
        procFunc(number)