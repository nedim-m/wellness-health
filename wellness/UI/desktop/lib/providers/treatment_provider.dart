import '../models/treatment.dart';
import 'base_provider.dart';

class TreatmentProvider extends BaseProvider<Treatment> {
  TreatmentProvider() : super("Treatment");

  @override
  Treatment fromJson(data) {
    return Treatment.fromJson(data);
  }
  
  
}
