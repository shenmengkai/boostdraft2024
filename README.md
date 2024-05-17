# Pull request description-like document (write/modify whatever you want, including this title) 

## Details
initial PR of xml validator

## Usage

```console
> checker.exe "<Design><Code>hello world</Code></Design>"
Valid
```
```console
> checker.exe "<Design><Code>hello world</Code></Design><People>"
Invalid
```

## Enviroment
.NET 7

## Implementation
Principle is that use stack to validate XML tags in order.

| Folder|Module|Description|
|-:|-|-|
| Services/| SimpleXmlValidator|Main entrypoint. Document level rules definition.|
| Models/|TagStack|Collect the relations between XML tags and documents.|
| |XmlComponent|Defines Xml tag types and utility to grap tags.|

## Test
Test.csproj is xUnit project to manage related test cases

|Test|Description|
|-|-|
|SimpleXmlValidatorTest|Document level cases. Simulate the input received from command line parameters|
|XmlComponentTest|Xml tag property cases of all types, start/end/self-closing|

## PR Author Checklist
- [v] wrote clear testing steps that cover the changes made in this PR 
- [v] ran the tests & verified they passed
- [v] verified there are no console errors
- [v] verified there is no console dummy outputs
  