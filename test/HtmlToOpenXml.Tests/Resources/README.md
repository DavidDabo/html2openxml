# Markdown File

To be able to read a resource file from within your test, you need to add it to the "Resources" folder.
Mark the file with "build: none" and "copy:always". After building, it should appear in the .../bin/Debug/net48/Resources bzw .../bin/Debug/netcoreapp3.1/Resources.
Use the ResourceHelper::GetFileContentFromResources to load the file.