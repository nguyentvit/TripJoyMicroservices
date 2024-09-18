#!/bin/bash
set -e

# Đợi cho PostgreSQL khởi động
echo "Waiting for PostgreSQL to start..."
until pg_isready -U "$POSTGRES_USER" -d "$POSTGRES_DB"; do
  sleep 1
done

# Kiểm tra nếu database đã tồn tại
if psql -U "$POSTGRES_USER" -d "$POSTGRES_DB" -c '\dt' | grep -q 'No relations found'; then
  echo "Database is empty. Running SQL script..."
  psql -U "$POSTGRES_USER" -d "$POSTGRES_DB" -f /docker-entrypoint-initdb.d/CreateTables.sql
else
  echo "Database already exists. Skipping SQL script."
fi