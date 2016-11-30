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

    sbrp -s ..\..\samples\0\bus-stops.txt -d ..\..\samples\0\dmat.txt -b 7
    
The sample problem includes

* 40 bus stops
* 198 students

Run the above command, we accept default parameters:

* bus capacity is 30 student
* the crossover rate is 0.95
* the mutation rate is 0.1
* the population is 200
* the number of generation is 200
* the number of elites in each generation is 5
    
The `-b` option tells the program that we want to limit the number of buses to 7 ones. I choose 7 buses because this is the minimum number of buses that can carry 198 students to school.

## Sample output

This sample output tells us that after 200 generations, the genetic algorithm found a good solution for 7 buses with the total riding time is 153.600 minutes. We can get the route of each bus as well as the number student in each one. The output file is saved as `routes.txt` in the same directory with the executable file.

    Generation:   0 - Best solution fitness 2344.183 ( 404.017 minutes)
    Generation:   1 - Best solution fitness 1531.400 ( 328.900 minutes)
    Generation:   2 - Best solution fitness 1421.650 ( 315.817 minutes)
    Generation:   3 - Best solution fitness 1217.233 ( 301.567 minutes)
    Generation:   4 - Best solution fitness 1215.133 ( 298.800 minutes)
    Generation:   5 - Best solution fitness 1215.133 ( 298.800 minutes)
    Generation:   6 - Best solution fitness 1024.200 ( 281.533 minutes)
    Generation:   7 - Best solution fitness 1001.817 ( 281.983 minutes)
    Generation:   8 - Best solution fitness  898.467 ( 270.300 minutes)
    Generation:   9 - Best solution fitness  757.750 ( 259.583 minutes)
    Generation:  10 - Best solution fitness  757.750 ( 259.583 minutes)
    Generation:  11 - Best solution fitness  644.483 ( 248.317 minutes)
    Generation:  12 - Best solution fitness  568.933 ( 238.933 minutes)
    Generation:  13 - Best solution fitness  553.233 ( 239.900 minutes)
    Generation:  14 - Best solution fitness  478.750 ( 230.583 minutes)
    Generation:  15 - Best solution fitness  381.133 ( 222.967 minutes)
    Generation:  16 - Best solution fitness  362.583 ( 220.917 minutes)
    Generation:  17 - Best solution fitness  333.650 ( 213.483 minutes)
    Generation:  18 - Best solution fitness  305.567 ( 216.900 minutes)
    Generation:  19 - Best solution fitness  303.750 ( 217.083 minutes)
    Generation:  20 - Best solution fitness  271.767 ( 207.767 minutes)
    Generation:  21 - Best solution fitness  271.767 ( 207.767 minutes)
    Generation:  22 - Best solution fitness  255.400 ( 207.900 minutes)
    Generation:  23 - Best solution fitness  251.867 ( 204.700 minutes)
    Generation:  24 - Best solution fitness  225.683 ( 197.350 minutes)
    Generation:  25 - Best solution fitness  224.783 ( 196.450 minutes)
    Generation:  26 - Best solution fitness  217.967 ( 189.633 minutes)
    Generation:  27 - Best solution fitness  212.383 ( 200.717 minutes)
    Generation:  28 - Best solution fitness  205.683 ( 189.683 minutes)
    Generation:  29 - Best solution fitness  202.933 ( 190.267 minutes)
    Generation:  30 - Best solution fitness  191.967 ( 188.800 minutes)
    Generation:  31 - Best solution fitness  191.967 ( 188.800 minutes)
    Generation:  32 - Best solution fitness  191.433 ( 188.267 minutes)
    Generation:  33 - Best solution fitness  188.350 ( 188.350 minutes)
    Generation:  34 - Best solution fitness  174.967 ( 174.967 minutes)
    Generation:  35 - Best solution fitness  174.967 ( 174.967 minutes)
    Generation:  36 - Best solution fitness  170.317 ( 170.317 minutes)
    Generation:  37 - Best solution fitness  170.017 ( 170.017 minutes)
    Generation:  38 - Best solution fitness  169.183 ( 169.183 minutes)
    Generation:  39 - Best solution fitness  168.267 ( 168.267 minutes)
    Generation:  40 - Best solution fitness  166.933 ( 166.933 minutes)
    Generation:  41 - Best solution fitness  166.933 ( 166.933 minutes)
    Generation:  42 - Best solution fitness  166.933 ( 166.933 minutes)
    Generation:  43 - Best solution fitness  166.933 ( 166.933 minutes)
    Generation:  44 - Best solution fitness  166.933 ( 166.933 minutes)
    Generation:  45 - Best solution fitness  166.933 ( 166.933 minutes)
    Generation:  46 - Best solution fitness  165.450 ( 165.450 minutes)
    Generation:  47 - Best solution fitness  165.450 ( 165.450 minutes)
    Generation:  48 - Best solution fitness  165.100 ( 165.100 minutes)
    Generation:  49 - Best solution fitness  161.400 ( 161.400 minutes)
    Generation:  50 - Best solution fitness  161.383 ( 161.383 minutes)
    Generation:  51 - Best solution fitness  161.117 ( 161.117 minutes)
    Generation:  52 - Best solution fitness  155.917 ( 155.917 minutes)
    Generation:  53 - Best solution fitness  155.917 ( 155.917 minutes)
    Generation:  54 - Best solution fitness  155.633 ( 155.633 minutes)
    Generation:  55 - Best solution fitness  155.633 ( 155.633 minutes)
    Generation:  56 - Best solution fitness  155.633 ( 155.633 minutes)
    Generation:  57 - Best solution fitness  155.633 ( 155.633 minutes)
    Generation:  58 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  59 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  60 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  61 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  62 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  63 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  64 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  65 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  66 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  67 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  68 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  69 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  70 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  71 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  72 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  73 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  74 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  75 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  76 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  77 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  78 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  79 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  80 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  81 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  82 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  83 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  84 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  85 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  86 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  87 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  88 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  89 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  90 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  91 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  92 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  93 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  94 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  95 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  96 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  97 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  98 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation:  99 - Best solution fitness  155.283 ( 155.283 minutes)
    Generation: 100 - Best solution fitness  154.300 ( 154.300 minutes)
    Generation: 101 - Best solution fitness  154.300 ( 154.300 minutes)
    Generation: 102 - Best solution fitness  154.300 ( 154.300 minutes)
    Generation: 103 - Best solution fitness  154.300 ( 154.300 minutes)
    Generation: 104 - Best solution fitness  154.283 ( 154.283 minutes)
    Generation: 105 - Best solution fitness  154.233 ( 154.233 minutes)
    Generation: 106 - Best solution fitness  154.233 ( 154.233 minutes)
    Generation: 107 - Best solution fitness  154.233 ( 154.233 minutes)
    Generation: 108 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 109 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 110 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 111 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 112 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 113 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 114 - Best solution fitness  153.950 ( 153.950 minutes)
    Generation: 115 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 116 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 117 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 118 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 119 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 120 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 121 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 122 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 123 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 124 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 125 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 126 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 127 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 128 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 129 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 130 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 131 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 132 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 133 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 134 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 135 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 136 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 137 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 138 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 139 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 140 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 141 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 142 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 143 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 144 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 145 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 146 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 147 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 148 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 149 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 150 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 151 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 152 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 153 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 154 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 155 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 156 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 157 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 158 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 159 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 160 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 161 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 162 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 163 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 164 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 165 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 166 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 167 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 168 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 169 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 170 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 171 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 172 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 173 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 174 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 175 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 176 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 177 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 178 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 179 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 180 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 181 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 182 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 183 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 184 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 185 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 186 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 187 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 188 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 189 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 190 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 191 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 192 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 193 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 194 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 195 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 196 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 197 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 198 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 199 - Best solution fitness  153.600 ( 153.600 minutes)
    Generation: 200 - Best solution fitness  153.600 ( 153.600 minutes)
    
    Solution found
    Bus  0 ( 6 stops) 18.567 minutes,  30 students: 17, 36, 30, 18, 21, 5
    Bus  1 ( 6 stops) 17.867 minutes,  30 students: 2, 26, 4, 20, 19, 15
    Bus  2 ( 5 stops) 29.783 minutes,  25 students: 31, 12, 25, 27, 16
    Bus  3 ( 6 stops) 25.233 minutes,  29 students: 11, 14, 24, 29, 39, 3
    Bus  4 ( 6 stops) 26.750 minutes,  29 students: 33, 34, 37, 23, 32, 13
    Bus  5 ( 6 stops) 25.250 minutes,  29 students: 28, 35, 7, 9, 22, 1
    Bus  6 ( 5 stops) 10.150 minutes,  25 students: 10, 40, 6, 38, 8
    
    Done.
