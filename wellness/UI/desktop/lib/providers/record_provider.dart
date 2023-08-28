import '../models/record.dart';
import 'base_provider.dart';

class RecordProvider extends BaseProvider<Records> {
  RecordProvider() : super("Record");

  @override
  Records fromJson(data) {
    return Records.fromJson(data);
  }
}
