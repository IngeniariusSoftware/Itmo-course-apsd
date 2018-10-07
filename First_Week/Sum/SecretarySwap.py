input = open('input.txt');
length = int(input.readline());
tokens = [int(element) for element in input.readline().split(' ')];
input.close();
output = open('output.txt' , 'w');
i = 0;
swapped = True;
while swapped:
    swapped = False
    for i in xrange(length):
        if l[i] > l[i+1]:
            l[i],l[i+1] = l[i+1],l[i];
            swapped = True
while i < length:
    if sort.count(int(tokens[i])) > 0:
        position = sort.index(int(tokens[i]));
        shelf = tokens[i];
        tokens[i] = tokens[position];
        tokens[position] = shelf;
        sort[position] = 'empty';
        if i < position:
            output.write('Swap elements at indices ' + str(i + 1) + ' and ' + str(position + 1) + '.\n');
            i = 0;
        if i > position:
            output.write('Swap elements at indices ' + str(position + 1) + ' and ' + str(i + 1) + '.\n');
            i = 0;
        if i == position:
            i += 1;
    else:
        i += 1;
output.write('No more swaps needed.\n');
for element in tokens:
    output.write(str(element) + ' ');
output.close();
