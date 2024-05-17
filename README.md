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

## Test cases
Test.csproj is xUnit project to manage related test cases

### Test/SimpleXmlValidatorTest
Document level cases. Simulate the input received from command line parameters
- valids
```Csharp
[InlineData("<a></a>")]
[InlineData("<a/>")]
[InlineData("<a>x</a>")]
[InlineData("<a><b/></a>")]
[InlineData("<a><b></b></a>")]
[InlineData("<a><b>x</b></a>")]
[InlineData("<a><b></b>x</a>")]
[InlineData("<a><b/>x</a>")]
```
- invalids
```csharp
[InlineData("<>")]
[InlineData("<a>")]
[InlineData("<a></a><")]
[InlineData("<a></a>x")]
[InlineData("<a>x</a><")]
[InlineData("<a t=\"1\"></a>")]
[InlineData("<a><b></b>")]
[InlineData("<a><b></a>")]
[InlineData("<a></a><b></b>")]
```

### Test/XmlComponentTest
Xml tag property cases of all types, start/end/self-closing
- strings should ok to extract tag
```csharp
[InlineData("<a>", 0, 3, "a", XmlComponentType.StartTag)]
[InlineData("</a>", 0, 4, "a", XmlComponentType.EndTag)]
[InlineData("<a >", 0, 4, "a", XmlComponentType.StartTag)]
[InlineData("xxx</a>", 0, 7, "a", XmlComponentType.EndTag)]
[InlineData("xxx</a>", 3, 7, "a", XmlComponentType.EndTag)]
```
- strings should fails to extract tag
```csharp
[InlineData("", 0)]
[InlineData(" ", 0)]
[InlineData("a", 0)]
[InlineData("<", 0)]
[InlineData(">", 0)]
[InlineData("<<a>", 0)]
[InlineData("><a>", 0)]
[InlineData("<a>", 1)]
```

![boostdraft-test](https://github.com/shenmengkai/boostdraft2024/assets/15992122/8d3bf1f5-83b2-456c-ba7a-56a7925b0d3a)

## PR Author Checklist
- [x] wrote clear testing steps that cover the changes made in this PR 
- [x] ran the tests & verified they passed
- [x] verified there are no console errors
- [x] verified there is no console dummy outputs
  
