from collections.abc import Callable

class LazyMonad:

    def __init__(self, value: object):
        if isinstance(value, Callable):
            self.compute = value
        else:
            def return_val():
                return value
            self.compute = return_val

    def bind(self, f: Callable, *args, **kwargs) -> 'FailureMonad':
        def f_compute():
            return f(self.compute(), *args, **kwargs)
        return LazyMonad(f_compute)


def dummy_func1(e):
    print(f'dummy_1 : {e}')
    return e

def dummy_func2(e):
    print(f'dummy_2 : {e}')
    return e

def dummy_func3(e):
    print(f'dummy_3 : {e}')
    return e

print('Start')

value = 100
m1 = LazyMonad(value)
print('After init')
m2 = m1.bind(dummy_func1)
print('After 1')
m3 = m2.bind(dummy_func2)
print('After 2')
m4 = m3.bind(dummy_func3)
print('After 3')

print(m4.compute())

print('After Compute')

