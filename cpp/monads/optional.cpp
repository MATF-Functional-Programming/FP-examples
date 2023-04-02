#include <iostream>
#include <optional>
#include <string>
#include <vector>

template <typename T1, typename F>
auto transform(const std::optional<T1>& opt, F f)
    -> std::optional<decltype(f(opt.value()))>
{
    // Mozemo "testirati" da li optional ima vrednost
    // na trivijalan nacin
    if (opt) {
        return f(opt.value());
    } else {
        // https://en.cppreference.com/w/cpp/language/initialization
        return {};
    }
}


int main(int argc, char* argv[])
{
    // Kada pravimo optional, podrazumevano nema vrednost
    // Inace, mozemo koristiti std::make_optional()
    std::optional<int> i;

    auto res = transform(i, isalnum);

    return 0;
}
