def mergeSort(listToSort, left, right,output):
    if len(listToSort) > 1:
        mid = len(listToSort) // 2
        lefthalf = listToSort[:mid]
        righthalf = listToSort[mid:]

        mergeSort(lefthalf, left, left + mid-1, output)
        mergeSort(righthalf, left+mid, right,output)

        i = 0
        j = 0
        k = 0

        while i < len(lefthalf) and j < len(righthalf):
            if lefthalf[i] < righthalf[j]:
                listToSort[k] = lefthalf[i]
                i += 1
            else:
                listToSort[k] = righthalf[j]
                j += 1
                k += 1

        #первый дошли до конца
        while i < len(lefthalf):
            listToSort[k] = lefthalf[i]
            i += 1
            k += 1

        #Второй дошли ли до конца
        while j < len(righthalf):
            listToSort[k] = righthalf[j]
            j += 1
            k += 1
        temp_str = "%s %s %s %s\n" %(left,right,listToSort[0],listToSort[len(listToSort)-1])
        output.writelines(temp_str)
input = open('input.txt');
output = open('output.txt' , 'w');
arrLength = int(input.readline())
list = []
for line in input.readline().split(' '):
    list.append(int(line))
mergeSort(list, 1, len(list), output)
for x in list:
    output.write(str(x) + " ")