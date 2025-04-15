# Copilot Instructions
 
This is a website for an IT software consulting business. 
All employees are very experienced software developers and are expected to be able to write code without assistance.


## General Instructions
- Limit responses to one sentence especially for explanations.
- Projects in this repository should use the latest C# features.


## Team Best Practices
- always create files using file-scoped namespaces.
- When doing auth, always use .NET 8/9 idioms & auth state is optional/should be set to false by default.
- Prefer inline lambdas over full method bodies in C#.
- Prefer async and await over synchronous code.
- Never use CSS inline styles. Always use a CSS file.
- When creating Web API projects, prefer minimal APIs project.


## Testing Guidelines
- Use xUnit for unit tests.
- Use FluentAssertions version 7.2.0 for assertions.
- Use Moq for mocking.
- 