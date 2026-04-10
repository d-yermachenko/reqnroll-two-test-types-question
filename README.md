# Reqnroll shared feature files for two test types

This repository illustrates how to use the same Reqnroll Gherkin feature files for two different kinds of automated tests in the same solution:

- `Tests.Integration` for domain or integration-style verification
- `Tests.EToE` for UI verification with a separate binding implementation

## What this project demonstrates

The solution shows how to keep the business specification in one place and run it from multiple test projects.

The key idea is:

- store `.feature` files in a dedicated class library project: `Business.Specification`
- link those `.feature` files into each runnable test project
- keep separate step definitions in each test project
- let each test project generate its own Reqnroll code-behind

This allows the same scenario text to be executed twice:

- once against domain or integration logic
- once against the UI flow

## Solution structure

- `Business.Specification`
  - class library used only to hold shared Gherkin specifications
- `Tests.Integration`
  - Reqnroll test project with integration/domain bindings
- `Tests.EToE`
  - Reqnroll test project with UI bindings

## How it is achieved

### 1. Keep specifications in a separate class library

`Business.Specification` is a plain class library that contains the shared `.feature` files.

It does not act as a test project and does not run Reqnroll scenarios directly.

### 2. Link the shared feature files into each test project

Each runnable test project includes the shared feature files with a linked item like this:

```xml
<ReqnrollFeatureFile Include="..\Business.Specification\Specification\**\*.feature"
                     Link="Specification\%(RecursiveDir)%(Filename)%(Extension)" />
```

This makes the same feature file appear inside both test projects without duplicating the source file.

### 3. Generate code-behind in the destination project output folder

Because the `.feature` files are shared from another project, code-behind generation must not write back into the source specification folder.

Each runnable test project therefore enables:

```xml
<ReqnrollUseIntermediateOutputPathForCodeBehind>true</ReqnrollUseIntermediateOutputPathForCodeBehind>
```

This tells Reqnroll to generate the `.feature.cs` files in the destination project's `obj` folder instead of next to the shared `.feature` file.

That is the important part that keeps `Business.Specification` clean and prevents conflicts between projects.

### 4. Keep bindings isolated per test project

Both test projects use the same Gherkin text, but each project has its own step definition classes.

That means:

- `Tests.Integration` can map steps to domain/application behavior
- `Tests.EToE` can map the same steps to UI automation behavior

Reqnroll then discovers and runs the scenarios separately in each test assembly.

## Why this setup is useful

This setup is useful when you want one business-readable specification but more than one verification layer:

- fast domain/integration feedback
- end-to-end UI validation
- no duplication of feature files
- no ambiguous bindings in a single test assembly

## Summary

This repository is an example of using Reqnroll as a shared specification source across multiple test projects.

It combines:

- a dedicated specification project
- linked `ReqnrollFeatureFile` items
- per-project step definitions
- `ReqnrollUseIntermediateOutputPathForCodeBehind=true`

With this approach, one feature file can drive multiple kinds of tests in the same solution while keeping responsibilities separated.
