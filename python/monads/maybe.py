from collections.abc import Callable

class MaybeMonad:
    def __init__(self, value: object = None, contains_value: bool = True):
        self.value = value
        self.contains_value = contains_value

    def bind(self, f: Callable) -> 'MaybeMonad':
        if not self.contains_value:
            return MaybeMonad(None, contains_value=False) 
        try:
            result = f(self.value)
            return MaybeMonad(result)
        except:
            return MaybeMonad(None, contains_value=False)


import numpy as np

value = 100
m1 = MaybeMonad(value)
print(m1.value) # 100
print(m1.contains_value) # True

m2 = m1.bind(np.sqrt)
print(m2.value) # 10.0

m3 = m2.bind(lambda x : x / 0)  # runtime warning, not an exception
print(m3.contains_value) # True
print(m3.value) # inf

def exc(x):
    raise Exception('Failed')

m4 = m3.bind(exc)
print(m4.contains_value) # False

