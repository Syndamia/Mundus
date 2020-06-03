In this branch I will be adding features that are module requirements:
 - Using a databse
   - `MySQL` database
 - Using entity framework
   - `Microsoft.EntityFrameworkCore`
 - Unit tests 
   - `NUnit`
 - Following good practises for writing code
   - **Note:** I am not completely following these [rules](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/ReadabilityRules.md): 
     - SA1101 (some code will get very crowded)
     - SA1107 (only in switch statements)
     - SA1305 (only in some temporary variables)
     - SA1600 (only on very self-explanatory code)
     - SA1602 (the names are very obvious)
     - SA1611 (parameters are either self-explanatory, or have been explained in summary)
     - SA1615 (usually it is explained in the summary)
     - SA1633 (there isn't a need for document headers).

This program has more than 2000 lines of practical code (I don't count code that is repeated with minor differences). I have written, in total, more than 21000 lines of code in the process of making it for the last ~2,5 months (since 27.02).

I won't be integrating these features in any other versions of the project. Also many things are dependant on my setup, so I won't be adding a built executable.

For more information, visit [my website](http://www.syndamia.com/projects/mundus/introduction).

**This branch won't be pushed to `master` and, after the exam, will be left only for archiving purposes**.
