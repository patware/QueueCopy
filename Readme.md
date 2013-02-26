QueueCopy: A simple utility for copying files and/or folders using a Queue.

When copying files over the network or slow "destinations", or when copying a large amount of files/folders, or when copying large files, using Windows, there's one "thread" of copying for each "job".  The problem with multiple threads hacking the same output, they fight for that resource.

This utility queues up the "jobs" and has only one thread doing it as fast as it can.  

Current Version: 1.0

History:
-----------------

- 1.0 - 2008.03.27 - Created (I can't help laughing at the application's title: "MainForm".  Haha...) Ok... this will be part of the next changes.

Development:
-----------------
2013.2.25 - I started work on a new release of the application.  I'm starting from scratch: Visual Studio 2012, WPF, MVVM-Light at the base.  Here are the features:
  - New UI (WPF)
  - Many "jobs"
  - Named jobs
  - History
  - Favorites
  - Recent
  - Options
  - Copy vs Move
  - Different algorithms based on the target drive vs same drive, file size, target drive speed, move vs copy

