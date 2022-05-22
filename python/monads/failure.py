from collections.abc import Callable
from typing import Dict

import traceback

class FailureMonad:

    def __init__(self, value: object = None, error_status: Dict = None):
        self.value = value
        self.error_status = error_status

    def bind(self, f: Callable, *args, **kwargs) -> 'FailureMonad':
        if self.error_status:
            return FailureMonad(None, error_status=self.error_status)
        try:
            result = f(self.value, *args, **kwargs)
            return FailureMonad(result)
        except Exception as e:
            failure_status = {
                'trace' : traceback.format_exc(),
                'exc' : e,
                'args' : args,
                'kwargs' : kwargs
            }
            return FailureMonad(None, error_status=failure_status)


import numpy as np

def dummy_func(a, b, c=3):
    return a + b + c

def exc(x):
    raise Exception('Failed')

value = 100
m1 = FailureMonad(value)
print(m1.value) # 100

m2 = m1.bind(np.sqrt)
print(m2.value) # 10.0

m3 = m2.bind(dummy_func, 1, c=2)
print(m3.value) # 13.0

m4 = m3.bind(exc)
print(m4.value) # None
print(m4.error_status) # {'trace' : ..., 'args' : (...,), 'kwargs' : {...}}

