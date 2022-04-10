# [TiledCS](https://github.com/TheBoneJarmer/TiledCS) [MonoGame 3.8](https://github.com/mono/MonoGame) Example

This example shows how simple it is to draw a (TMX) map made with [Tiled](http://www.mapeditor.org/) in MonoGame project.

Used the `MonoGame Cross-Platform Desktop Application (OpenGL)` template.


## Notes:
The TMX and TSX map files is **not** supposed to be build with content pipeline. Just add it to the project and set **Copy if newer** from the files properties.

TiledCS does not seem to like embedded tilesets so make sure "Embed in map" is false when adding new tilesets in Tiled.
