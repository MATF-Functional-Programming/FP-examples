# via iterator class
class PowTwo:
    def __init__(self, max=0):
        self.n = 0
        self.max = max

    def __iter__(self):
        return self

    def __next__(self):
        if self.n > self.max:
            raise StopIteration
        result = 2 ** self.n
        self.n += 1
        return result

# via generator method
def PowTwoGen(max=0):
    n = 0
    while n < max:
        yield 2 ** n
        n += 1

