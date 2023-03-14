#include <iostream>
#include <vector>
#include <functional>

#include <range/v3/view.hpp>
#include <range/v3/action.hpp>
#include <range/v3/range/conversion.hpp>
#include <range/v3/view/istream.hpp>

using namespace ranges::v3;

std::string string_to_lower(const std::string &s) {
    return s | view::transform(tolower) | to<std::string>();
}

std::string string_only_alnum(const std::string &s) {
    return s | view::filter(isalnum) | to<std::string>();
}

int main(int argc, char *argv[])
{
    const int n = argc <= 1
                    ? 10
                    : atoi(argv[1]);

    const auto words = 
        istream_range<std::string>(std::cin)
            | view::transform(string_to_lower)
            | view::transform(string_only_alnum)
            | view::remove_if(&std::string::empty)
            | to_vector 
            | action::sort
            ;


    const auto results =
        words
            | view::group_by(std::equal_to<>())
            | view::transform([] (const auto &group) {
                const auto begin       = std::begin(group);
                const auto end         = std::end(group);
                const int  size        = distance(begin, end);
                const std::string word = *begin;
                return std::make_pair(size, word);
            })
            | to_vector 
            | action::sort
            ;


    for (auto value: results | view::reverse
                             | view::take(n)
    ) {
        std::cout << value.first << " " << value.second << std::endl;
    }

    return 0;
}

