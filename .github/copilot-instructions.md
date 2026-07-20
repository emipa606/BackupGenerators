# GitHub Copilot Instructions for Backup Generators Mod

## Mod Overview and Purpose
The Backup Generators mod provides backup power solutions in RimWorld, preventing blackouts and brownouts when battery reserves deplete. It extends the power system by introducing various generator types that start automatically when power reserves are critically low and shut off when reserves are sufficient.

## Key Features and Systems
- **Automatic Power Activation**: Generators activate when reserves reach 200 Wd and deactivate when above 1000 Wd.
- **Variety of Generator Types**:
  - Wood, Chemfuel, Mobile Chemfuel, Uranium, and Mobile Uranium, each with different power outputs and resource costs.
- **Mod Configurability**: Set low and high reserve thresholds in the mod settings.
- **New Artwork**: Unique graphics for generators, including special uranium versions.
- **Idling Fuel Consumption**: Generators consume minimal fuel even when not actively generating power.
- **Research Integration**: Generators unlock upon completing specific research projects.
- **Harmony Patching**: Utilizes Harmony patches to integrate with RimWorld's existing systems.

## Coding Patterns and Conventions
- **C# MonoBehaviour and Harmony Usage**: Key functionalities are implemented using Unity’s MonoBehaviour pattern, and game behaviors are modified using Harmony patches.
- **Single Responsibility Principle**: Classes are designed to have a singular purpose, such as `CompProperties_RefuelableDualConsumption.cs` focusing on dual fuel consumption logic.
- **Postfix Methods**: Harmony postfix methods are used to modify existing game behavior efficiently without overriding base functions, maintaining compatibility with other mods.
- **Consistent Naming**: Clear and descriptive naming conventions are used for classes and methods to ensure code readability and maintenance.

## XML Integration
- **Defs and Settings**: XML files define the properties of generators, including resource costs, capacity, and unlock requirements.
- **Patches for Compatibility**: Files like `owlchemist.simplefxsmoke.xml` are used for integrating with visual effects mods like Simple FX: Smoke.

## Harmony Patching
- **Purpose**: Used to extend and modify the game’s core functionality to support dynamic generator activation and interaction with battery levels.
- **Example Usage**: Game start methods are patched to initialize generator behavior properly when a new game starts or resumes from save.
- **Version Handling**: Separate Harmony versions are maintained for different RimWorld releases (e.g., Harmony 1.2 for version 1.0 and Harmony 2 for version 1.1).

## Suggestions for Copilot
- **Code Suggestions**: Utilize Copilot to generate repetitive XML definitions or boilerplate Harmony patches, allowing you to focus on unique logic implementations.
- **Event Handling**: Use Copilot’s AI capabilities to suggest patterns for event-driven generator activation based on in-game events or resource thresholds.
- **Configuration Management**: Leverage Copilot for assisting with the creation and maintenance of configurable settings in the mod’s settings menus.
- **Testing Assistance**: Auto-generate test methods to ensure that generator activation and deactivation logic is correctly implemented and triggers under the expected conditions.

This document outlines key aspects and best practices for collaborating with GitHub Copilot in the context of the Backup Generators mod for RimWorld, providing a solid foundation for its ongoing development and maintenance.

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

