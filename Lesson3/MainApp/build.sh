#!/bin/sh
echo "Building Implementations ..."
cd ../Implementations/CirclePlugin
dotnet build
cd ../RectanglePlugin
dotnet build
cd ../TrianglePlugin
dotnet build
echo "Done building implementations"

echo "Building main app"
cd ../../MainApp
dotnet build
echo "Main App Build done"

cp ../Implementations/CirclePlugin/bin/Debug/netstandard2.0/*.dll ./bin/Debug/netcoreapp2.0/Plugins/
cp ../Implementations/RectanglePlugin/bin/Debug/netstandard2.0/*.dll ./bin/Debug/netcoreapp2.0/Plugins/
cp ../Implementations/TrianglePlugin/bin/Debug/netstandard2.0/*.dll ./bin/Debug/netcoreapp2.0/Plugins/

