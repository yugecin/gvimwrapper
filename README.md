## gvimwrapper
A wrapper program around vim to add a filetree and clickable tablist because I frequently miss those things when being in vim all day. There probably is a better way.

## Preview
![c_](https://user-images.githubusercontent.com/12662260/37429933-0a3cb56c-27d1-11e8-93fb-a8bddab8a3ed.gif)

## Notes/bugs
* Icons are loaded from the `gvimwrappericons` folder. Add a file like `bla.ico` to use that icon for files with the `bla` extension.
* When trying to resize or scrolling in the file tree, click somewhere in the filetree first to make sure the wrapper gets focused. Otherwise the focus will return to vim and resizing/scrolling won't work.
