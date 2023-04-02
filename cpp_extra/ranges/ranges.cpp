#include <iostream>
#include <vector>
#include <functional>
#include <algorithm>
#include <utility>

#include <range/v3/view.hpp>
#include <range/v3/action.hpp>
#include <range/v3/range/conversion.hpp>
#include <range/v3/view/istream.hpp>

namespace ranges = ranges::v3;
namespace view = ranges::v3::view;
namespace action = ranges::v3::action;

std::vector<int> v { 1, 1, 2, 3, 5, 8, 13, 21, 34 };
std::vector<int> x { 21, 1, 3, 8, 13, 1, 5, 2 };
std::vector<std::string> words {
    "Lorem", " ", "ipsum", " ", 
    "dolor", " ", "sit", " ", 
    "amet"};
auto text = "Lorem ipsum dolor sit amet";

auto print_elem = [](auto const e) {
    std::cout << e << std::endl;
};

auto is_even = [](auto const i) {
    return i % 2 == 0; 
};


void print_non_range() {
    for (auto const i : v) {
       print_elem(i); 
    }

    // or
    
    std::for_each(std::cbegin(v), std::cend(v), print_elem);
}

void print_range() {
    ranges::for_each(std::cbegin(v), std::cend(v), print_elem);

    // or
    
    ranges::for_each(std::as_const(v), print_elem);
}


void print_reverse_non_range() {
    std::for_each(std::crbegin(v), std::crend(v), print_elem);
}

void print_reverse_range() {
    ranges::for_each(std::crbegin(v), std::crend(v), print_elem);
    
    // but also:

    for (auto const i : v | view::reverse) {
        print_elem(i);
    }
}


void print_even_reverse_non_range() {
    std::for_each(
        std::crbegin(v), 
        std::crend(v),
        [](auto const i) { if (i % 2 == 0) print_elem(i); }
    );
}

void print_even_reverse_range() {
    for (auto const i : v | view::reverse 
                          | view::filter(is_even)) 
    {
       print_elem(i);
    }
}


void print_even_skip2_take3_non_range() {
    auto it = std::cbegin(v);
    std::advance(it, 2);
    auto ix = 0;
    while (it != std::cend(v) && ix++ < 3) {
        if (is_even(*it))
            print_elem(*it);
        it++;
    }
}

void print_even_skip2_take3_range() {
    for (auto const i : v | view::drop(2)
                          | view::take(3)
                          | view::filter(is_even))
    {
       print_elem(i);
    }
}


// Modify an unsorted range so that it retains only the unique values but in reverse order
void foo1_non_range() {
    std::sort(std::begin(x), std::end(x));
    x.erase(
        std::unique(std::begin(x), std::end(x)), 
        std::end(x)
    );
    std::reverse(std::begin(x), std::end(x));
}

void foo1_range() {
    x = std::move(x) 
        | action::sort 
        | action::unique 
        | action::reverse;
}


// Remove the smallest two and the largest two values of a range and retain the other ones, ordered, in a second range
void foo2_non_range() {
    std::vector<int> x2 = x;
    std::sort(std::begin(x2), std::end(x2));
          
    auto first = std::begin(x2);
    std::advance(first, 2);
    auto last = first;
    std::advance(last, std::size(x2) - 4);
    x2.erase(last, std::end(x2));
    x2.erase(std::begin(x2), first);
}

void foo2_range() {
    auto x2 = x
        | ranges::copy 
        | action::sort 
        | action::slice(2, ranges::end - 2);
}


void concat_all_strings_non_range() {
    std::string text;
    for (auto const &word : words)
        text += word;
}

void concat_all_strings_range() {
    std::string text = words | ranges::move | action::join;
}


size_t word_count_non_range() {
    std::istringstream iss(text);
    std::vector<std::string> words(
        std::istream_iterator<std::string>{iss},
        std::istream_iterator<std::string>()
    );
    return words.size();
    
    // or
    
    size_t count = 0;
    std::vector<std::string> words;
    std::string token;
    std::istringstream tokenStream(text);
    while (std::getline(tokenStream, token, ' ')) {
        ++count;
    }
    return count;
}

size_t word_count_range() {
    return ranges::distance(view::c_str(text) | view::split(' '));
}

