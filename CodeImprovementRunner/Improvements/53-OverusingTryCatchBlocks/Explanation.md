Problem

Developers sometimes wrap every single operation in its own try/catch.
This leads to:

Excessive nesting and cluttered code.

Loss of readability.

Possible swallowing of exceptions at the wrong scope.

Solution

Use fewer, broader try/catch blocks where appropriate.

Handle exceptions at the right level of abstraction.

Catch only the exceptions you expect.

Let unexpected exceptions bubble up to a centralized handler.

Benefits

Cleaner, more maintainable code.

Easier debugging and logging.

Separation of normal flow vs error handling.