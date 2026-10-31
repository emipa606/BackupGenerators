# GitHub Copilot Instructions for Backup Generators (Continued)

## Mod Overview and Purpose

The Backup Generators (Continued) mod is an update for DamnationLtd's original Backup Generators mod. It adds backup generators that provide power when the connected reserves are critically low, preventing blackouts or brownouts. The mod includes new art, configurable reserve values, and support for Simple FX: Smoke.

## Key Features and Systems

### Backup Generators
- **Wood Generator**: 1200W power, 75 capacity, 5 days active, 2 quadrums 7 days idle.
- **Chemfuel Generator**: 2100W power, 75 capacity, 7 1/2 days active, 1 year 2 quadrums idle.
- **Mobile Chemfuel Generator**: 900W power, 20 capacity, 1 1/3 days active, 12 1/2 days idle.
- **Uranium Generator**: 4000W power, 1 capacity, 10 days active, 2 years idle.
- **Mobile Uranium Generator**: 1800W power, 1 capacity, 5 days active, 1 year idle.

### Key Features
- **Configurable Low and High Reserve Values**: Set via mod settings.
- **Minified Generators**: Can be installed/uninstalled.
- **Heat Generation**: Heaters hint when placing generators.
- **Fuel Consumption**: Consumes fuel even when idle, but less than power-producing Vanilla fueled generators.

## Coding Patterns and Conventions

### C# Files
- **GameComponentUtility_LoadedGame.cs**: Contains a postfix patch for handling loaded games.
- **CompProperties_RefuelableDualConsumption.cs**: Defines properties for the refuelable dual consumption component.
- **CompRefuelableDualConsumption.cs**: Handles the refuelable dual consumption component, including ticking and consumption rate.
- **CompBackupPower.cs**: Manages backup power, including ticking and desired power output.
- **Main.cs**: Contains the main mod entry point.

### XML Files
- **BackupGenerator.xml**: Defines the backup generator thing def.
- **owlchemist.simplefxsmoke.xml**: Integrates Simple FX: Smoke for visual effects.
- **About.xml**: Contains mod metadata.
- **TranslationTemplate\ThingDef\BackupGenerator.xml**: Provides translation templates for thing definitions.

## XML Integration

The mod uses XML files to define game elements such as generators and visual effects. Key XML files include:

- **BackupGenerator.xml**: Contains the definition for the backup generator, including power output, capacity, and fuel consumption.
- **owlchemist.simplefxsmoke.xml**: Integrates Simple FX: Smoke to provide visual effects for the generators.

## Harmony Patching

The mod uses Harmony patching to modify Vanilla RimWorld behavior. Key patches include:

- **GameComponentUtility_LoadedGame.cs**: Postfix patch for handling loaded games.
- **CompRefuelableDualConsumption.cs**: Handles refuelable dual consumption component, including ticking and consumption rate.
- **CompBackupPower.cs**: Manages backup power, including ticking and desired power output.

## Suggestions for Copilot

### Coding Patterns
- Use postfix patches for handling loaded games.
- Define properties for refuelable dual consumption components.
- Implement refuelable dual consumption behavior, including ticking and consumption rate.
- Manage backup power behavior, including ticking and desired power output.

### XML Integration
- Define generator thing defs in XML, including power output, capacity, and fuel consumption.
- Integrate Simple FX: Smoke for visual effects.

### Harmony Patching
- Use Harmony to modify Vanilla RimWorld behavior.
- Implement postfix patches for handling loaded games.
- Define properties for refuelable dual consumption components.
- Implement refuelable dual consumption behavior, including ticking and consumption rate.
- Manage backup power behavior, including ticking and desired power output.

By following these guidelines and suggestions, you can effectively use GitHub Copilot to assist with the development of the Backup Generators (Continued) mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

