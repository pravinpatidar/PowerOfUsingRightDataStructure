Data Structure Benchmark: List<T> vs Dictionary<T>

This project demonstrates the performance differences between List<T> and Dictionary<T> when working with large hierarchical datasets.
The benchmark focuses specifically on lookup/search performance in both structures.

✅ Overview

The console application creates:

10,0000 parent items

Each parent contains 50 child items

Data is stored using:

A List<ParentItem>

A Dictionary<int, ParentItem>

The benchmark then compares how quickly each structure can locate:

A specific parent by ID

A specific child within that parent

✅ Why This Benchmark?

This example shows the practical difference between:

List<T>

O(n) lookup for parent items

O(n) lookup for child items

Good for sequential operations

Slow for repeated searches

Dictionary<TKey, TValue>

O(1) lookup for parent items

Only child lookup remains O(n)

Ideal for fast, repeated access

The benchmark allows you to see the measurable difference when the data is large.

✅ Benchmark Process

Generate 10,000 parent objects.

Each parent contains 50 child objects.

Populate both:

a List<ParentItem>

a Dictionary<int, ParentItem>

Search for:

Parent ID = 9876

Child ID = 40

Measure elapsed time using Stopwatch.

✅ Expected Results

Typically:

Dictionary<T> will be dramatically faster for parent lookups.

List<T> will require scanning through all parents, taking noticeably longer.

Child search time will be similar because both use a List for children.

This benchmark helps visualize why Dictionary<T> is the preferred structurewhen fast lookups are required.
