# Moving Forward From Basic FizzBuzz

Before we ended the face-to-face portion of the code screen, the engineer I spoke with left me with some homework. The first few pieces of homework were to implement the `yield` or dependency injection modifications and to add some unit tests to get some coverage going.

The second part of the test was more complicated: the users of our FizzBuzz Enterprise Suite wanted a bit more power over what they would evaluate for a FizzBuzz run and what the output would be, and they'd like to have as many conditions as they need. How would I go about implementing this?

I took some time to think on it, giving consideration to some unnecessarily wild ideas until I remembered that the modulo operations are just functions: they take in two numbers and spit out a true/false value as the result of the evaluation. The keyword here for me was "functions" because my immediate next thought was that I could generate `Func`s for each modulo statement the user wanted.

My plan was this: end users wanted to be able to generate their own modulo statements and text to use as an indicator that the statement was true. These could be packaged in objects! My pseudocode was a little something like this:

```plaintext
class Modulo
{
    prop ModuloLogic: a Func<int, bool>
    prop Result: a string
}
```

This was a great start and I initially thought that was all I needed from that class. I knew what I needed next was something to generate the delegate that the modulo class would hold and construct the modulo objects. I had a feeling that I might have needed to implement a factory, but I didn't have any subclasses that derived from this Modulo class. 

In order to leave the idea open, I created a `ModuloStatementBuilder` class that was similar in purpose to a factory: it was simply in charge of constructing the modulo object. I did give it some responsibility, however. I used the `ModuloStatementBuilder` class to create each delegate that the modulo objects would be responsible for holding.

The method signatures for my builder class looked like:

```csharp
public class ModuloStatementBuilder
{
    public ModuloStatement Build(string resultToDisplay, params int[] moduli) { }

    private Func<int, bool> BuildModuloLogic(params int[] moduli) { }
}
```

I used `params int[]` because I wanted anyone who needed to create a modulo object to be able to check for division for just one number or as many numbers as they wanted/needed. It would allow for what was currently implemented in the hardcoded if/else statements where the code would check if a given number was divisible by 3 *and* 5. At this point, the flow was starting to come together at this point:

1. The user provides the requirements to the builder (the moduli and result string)
2. The builder generates the `Func` for the modulo operation
3. The builder then stores the newly-created `Func` and result string in a `ModuloStatement` object
4. The FizzBuzz class receives a list of these `ModuloStatement` objects and during the course of FizzBuzz-ing, evaluates each statement

What was nice about this workflow is that it was still easy to test; the same operations were occurring in regards to evaluating modulo expressions, all I needed to do was ensure that the `Assert` statements for the custom modulo expressions were validating that what the user specified was being yielded by the FizzBuzz operation.