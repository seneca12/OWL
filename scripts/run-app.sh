#!/bin/bash

dotnet watch -v run ConnectionStrings:OwlAppContext='Server=127.0.0.1;Database=OwlAppContext;User=sa;Password=qwerty!@#4;Trusted_Connection=False;MultipleActiveResultSets=true' --urls "https://localhost:5001;http://localhost:5000"