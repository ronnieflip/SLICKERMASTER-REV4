# SLICKERMASTER-REV4
## NSA Hacking Tool Recreation UnitedRake

This is a PoC for the NSA Hacking Tool __UnitedRake__, basically it's a complex RAT that allows a cool drag and drop treeview to modify, edit the group of the bots, moreover it has a different approach to the control of each implant. This is not finished yet, I'm releasing it for study purposes only but so far it works.

## Deployment

I'm zipping the 'Flag' folder because GitHub doesn't allow more than 100 files to upload, you just need to extract the entire folder inside the 'Debug' project folder and/or 'Release'.

## Some References are missed?

I tried to create the GUI closer to the original project so I used a custom TabControl, if visual studio can't find the .DLL just add a reference to the project and select the DLL 'Jacksonsoft.CustomTabControl.dll' from the debug folder... or choose the reference from the shared project of the custom listview that should be inside the main solution.
