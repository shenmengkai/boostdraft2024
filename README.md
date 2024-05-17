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
Principle is to validate XML tags in order by stack structure.

|    Folder| Module             | Description |
|        -:| -                  | - |
| Services/| SimpleXmlValidator | XML validator service. |
|   Models/| XmlTagStack        | Collect the relations between XML tags. Defines orders, restriction and vialation in document level. |
|          | XmlComponent       | Defines all kinds of XML tag and utility to extract tags. It contains valid charaters, syntax and formats, |

## Test
Test.csproj is xUnit project to manage related test cases

| Test                   | Description |
| -                      | - |
| SimpleXmlValidatorTest | Document level cases. Simulate the input received from command line parameters |
| XmlComponentTest       | Xml tag property cases of all types, start/end/self-closing |

![boostdraft-test](https://github.com/shenmengkai/boostdraft2024/assets/15992122/8d3bf1f5-83b2-456c-ba7a-56a7925b0d3a)

## PR Author Checklist
- [x] wrote clear testing steps that cover the changes made in this PR 
- [x] ran the tests & verified they passed
- [x] verified there are no console errors
- [x] verified there is no console dummy outputs
  
