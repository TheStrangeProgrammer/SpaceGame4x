# SpaceGame4x
 
# V1
# https://github.com/shadowplaycoding/4XSpaceGame

# V2
# https://github.com/shadowplaycoding/4xspacegamev2

# Triangle net port
# https://github.com/Ranguna/Triangle-NET-Unity-Port

# Hull delanuay
# https://github.com/Scrawk/Hull-Delaunay-Voronoi

# another Velanuay implementation
# https://straypixels.net/delaunay-triangulation-terrain/

# full tutorial
# https://www.habrador.com/tutorials/math/11-delaunay/

# Here's another option in case you're interested. The 4X game Space Empires uses rules similar to the following in order to generate a star map. Example star map. Caveat: Occasionally warp paths will cross each other when using this algorithm.

#    Stars are positioned randomly on a discrete grid (roughly 50x50)

#    Each star is connected via warps to its closest 5 neighbors, in order of distance, with the additional constraint that the minimum angle between warps is 60 degrees

# Some of the above parameters are configurable, of course. This algorithm tends to produce plenty of interesting looking cycles and occasional dead ends.

# Orphaned stars are very unlikely, but you'd still need to check for those and either restart from scratch or delete the orphaned star.