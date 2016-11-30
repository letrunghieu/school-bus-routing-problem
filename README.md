# school-bus-routing-problem
Solve the school bus routing problem with a genetic algorithm developed by Kang (2015)

This implementation is a demostration for the course work of my master class. The algorithm is described in [this paper](http://www.sersc.org/journals/IJSEIA/vol9_no5_2015/11.pdf):

> Kang, M., Kim, S., Felan, J. T., Choi, H. R., & Cho, M. (2015). Development of a Genetic Algorithm for the School Bus Routing Problem. International Journal of Software Engineering and Its Applications, 9(5), 107–126. https://doi.org/10.14257/ijseia.2015.9.5.11

Build this solution with Visual Studio. The output file is named `SBRP.exe`. Run it to get the detail usage.

## Input

There is one sample input in this repository ([`SBRP\samples\0`](SBRP/samples/0) folder). That is also the input used to assess all proposed solutions in my class.

* [bus-stops.txt](SBRP/samples/0/bus-stops.txt) file: a TSV (tab separated values) file contain list of bus stops. The school is considered as the 0th "bus stop" in the list. Each row includes: the id, the latitude, the longitude and the number of students who stand at that bus stop.
* [dmat.txt](SBRP/samples/0/dmat.txt) file: a TSV file contain the list representaion of the distance matrix between all "bus stops" (the school is considered as the 0th bus stop). Each row contains the ids of two bus stop, the distance in meteres and the time in second when moving from the target bus stop to the another one.

## Run the demo data

After successfully build the solution in the default "Debug" build configuration, open the command line and change the current directory to `\SBRP\bin\debug` folder which contains the output executable file and run the command below:

    sbrp -s ..\..\samples\0\bus-stops.txt -d ..\..\samples\0\dmat.txt -b 8
    
The `-b` option tells the program that we want to limit the number of buses to 8 ones.

## Sample output

This sample output tells us that after 100 generations, the genetic algorithm found a good solution for 8 buses with the total riding time is 177.317 minutes. We can get the route of each bus as well as the number student in each one. The output file is saved as `routes.txt` in the same directory with the executable file.

    Generation:   0 - Best solution fitness 2306.967
    Generation:   1 - Best solution fitness 1497.417 ( 332.250 minutes)
    Generation:   2 - Best solution fitness 1423.383 ( 335.550 minutes)
    Generation:   3 - Best solution fitness 1153.600 ( 316.933 minutes)
    Generation:   4 - Best solution fitness 1054.367 ( 314.033 minutes)
    Generation:   5 - Best solution fitness 1054.367 ( 314.033 minutes)
    Generation:   6 - Best solution fitness  770.317 ( 270.983 minutes)
    Generation:   7 - Best solution fitness  766.383 ( 267.050 minutes)
    Generation:   8 - Best solution fitness  766.383 ( 267.050 minutes)
    Generation:   9 - Best solution fitness  682.100 ( 262.100 minutes)
    Generation:  10 - Best solution fitness  560.967 ( 256.800 minutes)
    Generation:  11 - Best solution fitness  560.967 ( 256.800 minutes)
    Generation:  12 - Best solution fitness  499.833 ( 244.833 minutes)
    Generation:  13 - Best solution fitness  499.833 ( 244.833 minutes)
    Generation:  14 - Best solution fitness  499.833 ( 244.833 minutes)
    Generation:  15 - Best solution fitness  499.833 ( 244.833 minutes)
    Generation:  16 - Best solution fitness  407.183 ( 247.350 minutes)
    Generation:  17 - Best solution fitness  407.183 ( 247.350 minutes)
    Generation:  18 - Best solution fitness  378.200 ( 246.700 minutes)
    Generation:  19 - Best solution fitness  378.200 ( 246.700 minutes)
    Generation:  20 - Best solution fitness  375.133 ( 243.633 minutes)
    Generation:  21 - Best solution fitness  357.817 ( 237.650 minutes)
    Generation:  22 - Best solution fitness  351.150 ( 241.483 minutes)
    Generation:  23 - Best solution fitness  350.333 ( 243.167 minutes)
    Generation:  24 - Best solution fitness  315.633 ( 238.633 minutes)
    Generation:  25 - Best solution fitness  315.633 ( 238.633 minutes)
    Generation:  26 - Best solution fitness  297.933 ( 235.600 minutes)
    Generation:  27 - Best solution fitness  263.617 ( 228.283 minutes)
    Generation:  28 - Best solution fitness  254.400 ( 234.400 minutes)
    Generation:  29 - Best solution fitness  248.200 ( 227.367 minutes)
    Generation:  30 - Best solution fitness  232.950 ( 231.950 minutes)
    Generation:  31 - Best solution fitness  223.617 ( 219.783 minutes)
    Generation:  32 - Best solution fitness  223.617 ( 219.783 minutes)
    Generation:  33 - Best solution fitness  223.617 ( 219.783 minutes)
    Generation:  34 - Best solution fitness  215.233 ( 215.233 minutes)
    Generation:  35 - Best solution fitness  209.083 ( 209.083 minutes)
    Generation:  36 - Best solution fitness  208.117 ( 208.117 minutes)
    Generation:  37 - Best solution fitness  207.867 ( 207.867 minutes)
    Generation:  38 - Best solution fitness  206.483 ( 206.483 minutes)
    Generation:  39 - Best solution fitness  204.767 ( 204.767 minutes)
    Generation:  40 - Best solution fitness  202.667 ( 202.667 minutes)
    Generation:  41 - Best solution fitness  202.667 ( 202.667 minutes)
    Generation:  42 - Best solution fitness  198.900 ( 198.900 minutes)
    Generation:  43 - Best solution fitness  198.133 ( 198.133 minutes)
    Generation:  44 - Best solution fitness  194.417 ( 194.417 minutes)
    Generation:  45 - Best solution fitness  194.283 ( 194.283 minutes)
    Generation:  46 - Best solution fitness  192.800 ( 192.800 minutes)
    Generation:  47 - Best solution fitness  192.800 ( 192.800 minutes)
    Generation:  48 - Best solution fitness  191.283 ( 191.283 minutes)
    Generation:  49 - Best solution fitness  187.317 ( 187.317 minutes)
    Generation:  50 - Best solution fitness  187.317 ( 187.317 minutes)
    Generation:  51 - Best solution fitness  187.317 ( 187.317 minutes)
    Generation:  52 - Best solution fitness  183.933 ( 183.933 minutes)
    Generation:  53 - Best solution fitness  183.767 ( 183.767 minutes)
    Generation:  54 - Best solution fitness  183.767 ( 183.767 minutes)
    Generation:  55 - Best solution fitness  183.767 ( 183.767 minutes)
    Generation:  56 - Best solution fitness  183.400 ( 183.400 minutes)
    Generation:  57 - Best solution fitness  182.167 ( 182.167 minutes)
    Generation:  58 - Best solution fitness  182.167 ( 182.167 minutes)
    Generation:  59 - Best solution fitness  182.167 ( 182.167 minutes)
    Generation:  60 - Best solution fitness  181.800 ( 181.800 minutes)
    Generation:  61 - Best solution fitness  181.750 ( 181.750 minutes)
    Generation:  62 - Best solution fitness  181.750 ( 181.750 minutes)
    Generation:  63 - Best solution fitness  181.750 ( 181.750 minutes)
    Generation:  64 - Best solution fitness  181.750 ( 181.750 minutes)
    Generation:  65 - Best solution fitness  181.750 ( 181.750 minutes)
    Generation:  66 - Best solution fitness  181.617 ( 181.617 minutes)
    Generation:  67 - Best solution fitness  181.350 ( 181.350 minutes)
    Generation:  68 - Best solution fitness  181.333 ( 181.333 minutes)
    Generation:  69 - Best solution fitness  180.300 ( 180.300 minutes)
    Generation:  70 - Best solution fitness  178.917 ( 178.917 minutes)
    Generation:  71 - Best solution fitness  178.917 ( 178.917 minutes)
    Generation:  72 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  73 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  74 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  75 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  76 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  77 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  78 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  79 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  80 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  81 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  82 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  83 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  84 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  85 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  86 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  87 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  88 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  89 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  90 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  91 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  92 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  93 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  94 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  95 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  96 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  97 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  98 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation:  99 - Best solution fitness  177.317 ( 177.317 minutes)
    Generation: 100 - Best solution fitness  177.317 ( 177.317 minutes)
    
    Solution found
    Bus  0 ( 6 stops) 27.917 minutes,  30 students: 31, 12, 30, 18, 21, 16
    Bus  1 ( 2 stops) 22.383 minutes,   9 students: 28, 9
    Bus  2 ( 5 stops) 28.650 minutes,  25 students: 7, 35, 36, 32, 23
    Bus  3 ( 4 stops) 12.683 minutes,  20 students: 40, 38, 10, 5
    Bus  4 ( 5 stops) 29.750 minutes,  24 students: 11, 14, 37, 19, 15
    Bus  5 ( 6 stops) 18.167 minutes,  30 students: 2, 26, 4, 20, 17, 13
    Bus  6 ( 6 stops) 22.383 minutes,  29 students: 34, 33, 24, 29, 22, 1
    Bus  7 ( 6 stops) 15.383 minutes,  30 students: 25, 27, 39, 3, 6, 8
    
    Done.
