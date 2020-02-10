# numbertoword
 
To Run:
RunMe\NumberToWordConverter.exe

inputFile.txt in this folder is the default file


My Design:
Program.cs is the entry point to the application and I've setup dependency injection where we can change implementations of the interfaces if required.

I saw the problem with 5 distinct parts:
1. Inputting
	Inputting is essentially getting data. IInputter is the starting point. Its implementation is FileInputter however this could have been	substituted with another implementation (from a streamed source for example). 

	For FileInputter I realised the filename could come from different sources (eg UI or the console). I created IInputterDialogue and its implementation ConsoleFileNameDialogue so that if we switched to a UI we were not dependendant on the console.
2. Parsing
	I created a generic parser interface and with a number parser. If we had a requirement to get specific words for a rules engine this could be substituted
3. Rules Engine
	From the output of the parser there is the functionality to process the rules. I created our example AmericanNumberFormatRulesEngine which would be different to a British number format where 1 billion is different. Again I used generics for input and output. We might not neccessarily be processing numbers.

	AmericanNumberFormatRulesEngine uses extention methods to make the logic more readable eg IsMillionsNumber
4. Rules Processing
	Processing rules could have different implementations. I used used Tasks to process the parsed items in a multi-threaded manner. I understand this is overkill and I tend to solve problems in the simplest way and then if there is an issue I would optimise. I wanted to demonstrate use of Tasks.
5. Outputting
	Similar to inputting I wanted to abstract us away from the console if this was for a UI. 

I have made it possible to return more than one number. I've made the assumption with the examples that these are isolated tests and not all together.

I've made use of SOLID principles.

When coding the challenge I've taken a TDD approach which in particular was useful for coding the rules ie AmericanNumberFormatRulesEngine. To tackle this i startedwith small numbers and made my way up. My unit test code is checked in.
