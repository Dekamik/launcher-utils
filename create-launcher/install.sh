#!/bin/bash
set -euo pipefail
IFS=$'\n\t'

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"

ln -s "$SCRIPT_DIR/create-launcher" "/usr/bin/create-launcher"
create-launcher -t --comment "Create launcher" -c System -c Utility "Create Launcher" create-launcher
